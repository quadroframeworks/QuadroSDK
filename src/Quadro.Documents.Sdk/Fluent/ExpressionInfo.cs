using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.Fluent
{
    public class ExpressionInfo
    {
        public static string GetNameFromMemberExpression(Expression expression)
        {
            var type = expression.GetType().ToString();

            if (expression is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (expression is MethodCallExpression methodexpression && methodexpression.Object is ConstantExpression expr && expr.Value is MethodInfo method)
            {
                return method.Name;
            }
            else if (expression is UnaryExpression unaryExpression)
            {
                return GetNameFromMemberExpression(unaryExpression.Operand);
            }
            else if (expression is InvocationExpression invocationExpression)
            {

            }
            else if (expression is DefaultExpression defaultExpression)
            {

            }
            else if (expression is ConstantExpression constantExpression)
            {

            }
            else if (expression is LambdaExpression lambdaExpression)
            {
                return GetNameFromMemberExpression(lambdaExpression.Body);
            }
            throw new Exception("Cannot retreive name from expression.");
        }

		public static string GetName<TDto>(Expression<Func<TDto, object>> expression)
		{
			var propertyname = GetNameFromMemberExpression(expression);
            return propertyname;
		}

		
	}

   
}
