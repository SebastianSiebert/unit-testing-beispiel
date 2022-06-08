using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beispiel.Anwendung.Model;

public class Level4Model
{
  [Key] public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Level4Property { get; set; }
  public List<string> ListProperty { get; set; }
  [ForeignKey("Level2Id")]
  public Level2Model Level2 { get; set; }
  [ForeignKey("Level3Id")]
  public Level3Model Level3 { get; set; }
  public Status Status { get; set; }
}