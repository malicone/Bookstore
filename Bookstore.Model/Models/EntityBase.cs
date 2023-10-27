using Bookstore.Model.Utils;
using Dapper.Contrib.Extensions;
using System;
using System.Linq;
using System.Reflection;

namespace Bookstore.Model
{
    /// <summary>
    /// Base class for all entities (models) from the db. Every entity is table in the db.
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Gets value of id (primary key). 
        /// </summary>
        /// <returns>Id of the entity.</returns>
        public virtual int GetEntityId()
        {
            PropertyInfo keyProperty = GetKeyProperty();
            if ( keyProperty != null )
            {
                var propValue = keyProperty.GetValue( this );
                if ( propValue != null )
                {
                    return int.Parse( propValue.ToString() );
                }
            }
            return default( int );
        }
        public virtual void SetEntityId( int value )
        {
            PropertyInfo keyProperty = GetKeyProperty();
            if ( keyProperty != null )
            {
                keyProperty.SetValue( this, value );
            }
        }

        public virtual string GetTableName()
        {
            string tableName = this.GetType().GetAttributeValue<TableAttribute, string>( attribute => attribute.Name );
            if ( tableName == null )
            {
                return this.GetType().Name;
            }
            return tableName;
        }
        public virtual string GetKeyName()
        {
            PropertyInfo keyProperty = GetKeyProperty();
            if ( keyProperty != null )
            {
                return keyProperty.Name;
            }
            return string.Empty;
        }

        public virtual string GetDefaultSortColumnName()
        {
            return GetKeyName();
        }
        protected virtual Type GetColumnType( string columnName )
        {
            var property = this.GetType().GetProperties().FirstOrDefault( p => p.Name.Equals( columnName ) );
            if ( property != null )
            {
                return property.PropertyType;
            }
            return null;
        }
        public virtual bool IsColumnTypeOfString( string columnName )
        {
            Type columnType = GetColumnType( columnName );
            if ( columnType != null )
            {
                return columnType == typeof( string );
            }
            return false;
        }
        public const int SYSTEM_RECORD_ID = 0;

        protected virtual PropertyInfo GetKeyProperty()
        {
            var properties = this.GetType().GetProperties();
            foreach ( var currentProperty in properties )
            {
                var attributes = currentProperty.GetCustomAttributes( typeof( KeyAttribute ), false );
                if ( attributes.Length > 0 )
                {                    
                    return currentProperty;
                }
                attributes = currentProperty.GetCustomAttributes( typeof( ExplicitKeyAttribute ), false );
                if ( attributes.Length > 0 )
                {
                    return currentProperty;
                }
            }
            return null;
        }
    }
}
