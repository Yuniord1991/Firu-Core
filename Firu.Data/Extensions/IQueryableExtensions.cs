using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Firu.Data.Extensions
{
    public static class IQueryableExtensions
    {
        private static readonly string[] RequestOriginAllowed = { "IsEngine" };

        public static IOrderedQueryable<T> PropertySorting<T>(this IQueryable<T> source, string property, string direction)
        {
            if (direction == "asc")
                return source.OrderBy(ToLambda<T>(property));
            else
                return source.OrderByDescending(ToLambda<T>(property));
        }

        public static IQueryable<T> ValidateOrigin<T>(this IQueryable<T> source, string requestOrigin = null) where T : class
        {
            if (requestOrigin == "IsEngine")
                return source.IgnoreQueryFilters();
            else
                return source;
        }

        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));
            var property = Expression.Property(parameter, propertyName);
            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
