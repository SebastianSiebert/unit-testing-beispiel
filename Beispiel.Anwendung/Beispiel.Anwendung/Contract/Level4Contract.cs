using Beispiel.Anwendung.Model;

namespace Beispiel.Anwendung.Contract;

public class Level4Contract
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string BaseProperty { get; set; }
  public string Level2Property { get; set; }
  public string Level3Property { get; set; }
  public string Level4Property { get; set; }
  public Status Status { get; set; }
}