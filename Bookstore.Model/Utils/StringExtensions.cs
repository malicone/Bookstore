using System;
using System.Collections.Generic;
using System.Text;

namespace Bookstore.Model.Utils
{
    public static class StringExtensions
    {
        public static string ToSqlParam( this string str )
        {
            return str.Replace( "'", "''" ).ToUpper();
        }
    }
}
