using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;

namespace Beispiel.Anwendung.Mapper;

public class Level4ContractMapperExample : IMapper<Level4Model, Level4Contract>
{
    /// <summary>
    /// Simplified Mapper Example, nur zum Test gedacht.
    /// Destination wird in diesem Beispiel ignoriert, es wird ein neues Level4Contract Object erstellt.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Level4Contract Map(Level4Model source, Level4Contract destination)
    {
        if (source is null) throw new ArgumentNullException(nameof(source));
        
        return new()
        {
          Id = source.Id,
          Name = source.Name,
          Description = source.Description,
          BaseProperty = source.Level2.Base.BaseProperty,
          Level2Property = source.Level2.Level2Property,
          Level3Property = source.Level3.Level3Property,
          Level4Property = source.Level4Property,
          IsCondition = source.Level2.IsCondition,
          Number = source.Level3.Number,
          ListProperty = source.ListProperty,
          Status = source.Status
        };
    }
}