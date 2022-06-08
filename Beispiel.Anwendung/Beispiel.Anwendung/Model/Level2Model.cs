using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beispiel.Anwendung.Model;

public class Level2Model
{
  [Key] public Guid Id { get; set; }
  public string Name { get; set; }
  public string Description { get; set; }
  public string Level2Property { get; set; }
  public bool IsCondition { get; set; }
  [ForeignKey("BaseId")]
  public BaseModel Base { get; set; }
  public Status Status { get; set; }
}