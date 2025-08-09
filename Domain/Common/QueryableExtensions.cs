using System.Linq.Expressions;

namespace School.Application.Common;

public static class QueryableExtensions
{
    public static IQueryable<T> ApplySorting<T>(this IQueryable<T> q, string? sortBy, string sortDir)
    {
        if (string.IsNullOrWhiteSpace(sortBy)) return q;
        var param = Expression.Parameter(typeof(T), "x");
        var prop = Expression.PropertyOrField(param, sortBy);
        var lambda = Expression.Lambda(prop, param);
        var method = (sortDir?.ToLowerInvariant() == "desc") ? "OrderByDescending" : "OrderBy";
        var call = Expression.Call(typeof(Queryable), method, new[] { typeof(T), prop.Type }, q.Expression, Expression.Quote(lambda));
        return q.Provider.CreateQuery<T>(call);
    }

    public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> q, int page, int pageSize)
        => q.Skip((Math.Max(page, 1) - 1) * Math.Max(pageSize, 1)).Take(Math.Max(pageSize, 1));
}
