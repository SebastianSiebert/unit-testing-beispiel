namespace Beispiel.Anwendung.Interfaces;

public interface IMapper<in TSource, TDestination>
    where TSource : class
    where TDestination : class
{
    TDestination Map(TSource source, TDestination destination);
}