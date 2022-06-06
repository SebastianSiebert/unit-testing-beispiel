using System.ComponentModel.DataAnnotations;

namespace Beispiel.Anwendung.Model;

public class BaseModel
{
  [Key] public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string BaseProperty { get; set; }
  public Status Status { get; set; }
}