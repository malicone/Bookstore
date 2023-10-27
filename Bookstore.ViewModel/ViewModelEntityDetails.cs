using Bookstore.Model;
using Bookstore.Model.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.ViewModel
{
    public abstract class ViewModelEntityDetails<T> : ViewModelBase where T : EntityBase, new()
    {
        public ViewModelEntityDetails() : base()
        {
            Repository = RepoFactory.GetRepoInstance<T>();
            EntityId = null;
            Entity = new T();
        }
        public T Entity { get; set; }
        public virtual int? EntityId { get; set; }
        protected virtual bool IsNewEntity
        {
            get { return EntityId == null; }
        }

        protected override void LoadDataToCache()
        {
            using (var transaction = Repository.Connection.BeginTransaction())
            {
                try
                {
                    LoadDataToCacheCommon(transaction);
                    if (IsNewEntity)
                    {
                        LoadDataToCacheForNewEntity(transaction);
                    }
                    else
                    {
                        LoadDataToCacheForExistingEntity(transaction);
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    FireDataExceptionEvent(ex);
                }
            }
        }
        protected virtual void LoadDataToCacheCommon(IDbTransaction transaction = null) { }
        protected virtual void LoadDataToCacheForNewEntity(IDbTransaction transaction = null) { }
        protected virtual void LoadDataToCacheForExistingEntity(IDbTransaction transaction = null)
        {
            Entity = Repository.Get(EntityId.Value, transaction);
        }

        protected override void CopyCacheToViewModel()
        {
            // nothing to do
        }
        protected override void SetTitle()
        {
            string entityName = Entity.GetTableName();
            Title = IsNewEntity ? $"New {entityName}" : $"Edit {entityName}";
        }

        public virtual bool ValidateViewModel(out string Errors)
        {
            Errors = string.Empty;
            return true;
        }
        public override bool Save()
        {
            ApplyViewModelToCache();
            using (var transaction = Repository.Connection.BeginTransaction())
            {
                try
                {
                    if (IsNewEntity)
                    {
                        InsertAction(transaction);
                    }
                    else
                    {
                        UpdateAction(transaction);
                    }
                    AfterSaveAction(transaction);
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    FireDataExceptionEvent(ex);
                    return false;
                }
            }
        }
        protected virtual void ApplyViewModelToCache() { }
        protected virtual void InsertAction(IDbTransaction transaction = null)
        {
            Repository.Add(Entity, transaction);
        }
        protected virtual void UpdateAction(IDbTransaction transaction = null)
        {

            Repository.Update(Entity, transaction);
        }
        protected virtual void AfterSaveAction(IDbTransaction transaction = null)
        {
            if (IsNewEntity)
            {
                EntityId = Entity.GetEntityId();
            }
        }

        public virtual bool Delete()
        {
            if (IsNewEntity == false)
            {
                return Repository.Delete(EntityId.GetValueOrDefault());
            }
            return false;
        }

        protected IRepoBase<T> Repository { get; private set; }        
    }
}