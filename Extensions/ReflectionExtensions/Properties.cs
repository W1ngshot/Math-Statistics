using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace ReflectionExtensions;

public static class Properties
{
    private static T GetAttribute<T>(this MemberInfo member, bool isRequired)
        where T : Attribute
    {
        var attribute = member.GetCustomAttributes(typeof(T), false).SingleOrDefault();

        if (attribute == null && isRequired)
        {
            throw new ArgumentException(
                string.Format(
                    CultureInfo.InvariantCulture, 
                    "The {0} attribute must be defined on member {1}", 
                    typeof(T).Name, 
                    member.Name));
        }

        return (T)attribute!;
    }

    public static string GetDisplayName<T>(Expression<Func<T, object>> exp)
    {
        var memberInfo = GetPropertyInformation(exp.Body);
        if (memberInfo == null)
        {
            throw new ArgumentException(
                "No property reference expression was found.",
                nameof(exp));
        }

        var attr = memberInfo.GetAttribute<DisplayNameAttribute>(true);
        return attr is null ? memberInfo.Name : attr.DisplayName;
    }

    private static MemberInfo? GetPropertyInformation(Expression propertyExpression)
    {
        Debug.Assert(propertyExpression != null, "propertyExpression != null");
        var memberExpr = propertyExpression as MemberExpression;
        if (memberExpr == null)
        {
            if (propertyExpression is UnaryExpression {NodeType: ExpressionType.Convert} unaryExpr)
            {
                memberExpr = unaryExpr.Operand as MemberExpression;
            }
        }

        return memberExpr is {Member.MemberType: MemberTypes.Property} ? memberExpr.Member : null;
    }
}