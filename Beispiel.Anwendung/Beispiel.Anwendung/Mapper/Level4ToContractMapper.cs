using System.Linq.Expressions;
using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;

namespace Beispiel.Anwendung.Mapper;

public class Level4ToContractMapper : IExpressionMapper<Level4Model, Level4Contract>
{
  public Expression<Func<Level4Model, Level4Contract>> Map() =>
    model => new()
    {
      Id = model.Id,
      Name = model.Name,
      Description = model.Description,
      BaseProperty = model.Level2.Base.BaseProperty,
      Level2Property = model.Level2.Level2Property,
      Level3Property = model.Level3.Level3Property,
      Level4Property = model.Level4Property,
      IsCondition = model.Level2.IsCondition,
      Number = model.Level3.Number,
      ListProperty = model.ListProperty,
      Status = model.Status
    };
}