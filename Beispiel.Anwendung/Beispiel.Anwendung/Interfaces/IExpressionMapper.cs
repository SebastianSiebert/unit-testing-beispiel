using System.Linq.Expressions;

namespace Beispiel.Anwendung.Interfaces;

public interface IExpressionMapper<TSource,TDestination>
  where TSource : class
  where TDestination : class
{
  Expression<Func<TSource, TDestination>> Map();
}