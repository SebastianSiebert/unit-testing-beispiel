using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beispiel.Anwendung.Model;

public class Level3Model
{
  [Key] public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Level3Property { get; set; }
  public int Number { get; set; }
  [ForeignKey("Level2Id")]
  public Level2Model Level2 { get; set; }
  public Status Status { get; set; }
}