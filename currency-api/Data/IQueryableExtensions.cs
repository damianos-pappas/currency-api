using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace currencyApi.Data
{
    public static class QueryExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            if (pageSize > 0 && pageNumber > 0)
            {
                IQueryable<T> result = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

                return result;
            }
            return source;
        }

        public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> source, string propertyName, bool orderDesc = false)
        {
            // LAMBDA: x => x.[PropertyName]
            var parameter = Expression.Parameter(typeof(TSource), "x");
            Expression property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            // REFLECTION: source.OrderBy(x => x.Property)
            MethodInfo orderByMethod;
            if (!orderDesc)
            {
                orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == "OrderBy" && x.GetParameters().Length == 2);
            }
            else
            {
                orderByMethod = typeof(Queryable).GetMethods().First(x => x.Name == "OrderByDescending" && x.GetParameters().Length == 2);
            }
            
            var orderByGeneric = orderByMethod.MakeGenericMethod(typeof(TSource), property.Type);
            var result = orderByGeneric.Invoke(null, new object[] { source, lambda });

            return (IOrderedQueryable<TSource>)result;
        }


    }
}