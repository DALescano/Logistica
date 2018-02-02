
using Med.Comun.Core.Pagination;
using Logistica.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;

namespace Logistica.Framework
{
    public static class SpecificationFilter
    {
       
        static Expression<Func<TEntity, bool>> builExpression<TEntity>(string name, object value)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var getter = Expression.Property(parameter, name);

            if (value == null)
                return null;

            if (getter.Type == typeof(string))
            {
                //string.Contains with string parameter.
                var stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                var containsCall = Expression.Call(getter, stringContainsMethod,
                    Expression.Constant(value, typeof(string)));

                return Expression.Lambda<Func<TEntity, bool>>(containsCall, parameter);
            }
            if (getter.Type == typeof(int))
            {
                var containsCall = Expression.Equal(getter, Expression.Constant(value,typeof(int)));
                return Expression.Lambda<Func<TEntity, bool>>(containsCall, parameter);

            }
            return null;
        }

        public static PagedResponse<TEntity> Apply<TEntity, TPagedRequest>(TPagedRequest pagedRequest, IQueryable<TEntity> List ) where TPagedRequest : PagedRequest
        {
            //if (pagedRequest == null)
            //{
            //    return List.PagedResponse(new PagedRequest() { Page = 1 , PageSize = 10 , Order = OrderPagedEnum.ASC });
            //}


            PropertyInfo[] filterProperties = typeof(TPagedRequest).GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in filterProperties)
            {
                if (pagedRequest.ColumnName == null)
                    pagedRequest.ColumnName = prop.Name;

                var propertyValue = ClassUtils.GetColumnAttributeValue(pagedRequest, prop.Name);

                var whereExp = builExpression<TEntity>(propertyValue, prop.GetValue(pagedRequest));
                if (whereExp == null)
                    continue;

                List = List.Where(whereExp);

            }

            var orderValue = ClassUtils.GetColumnAttributeValue(pagedRequest, pagedRequest.ColumnName);


            if (pagedRequest.Order == OrderPagedEnum.ASC)
                List = List.OrderBy(orderValue, "ASC");
            else
                List = List.OrderBy(orderValue, "DESC");

          
            var response = List.PagedResponse(pagedRequest);

            return response;
           
        }



        static int TotalPages(int totalItems, int itemsPerPage)
        {
            int totalPages = totalItems / itemsPerPage;

            if (totalItems % itemsPerPage != 0)
            {
                totalPages++; // Last page with only 1 item left
            }

            return totalPages;
        }
    }

}
