using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Microsoft.EntityFrameworkCore;

namespace Beispiel.Anwendung.Services;

public class AppDbContext : DbContext, IDbContext
{
  public DbSet<BaseModel> BaseModels { get; set; }
  public DbSet<Level2Model> Level2Models { get; set; }
  public DbSet<Level3Model> Level3Models { get; set; }
  public DbSet<Level4Model> Level4Models { get; set; }
  
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var level4 = CreateData();
    //modelBuilder.Entity<BaseModel>().HasData(level4.Level2.Base);
    //modelBuilder.Entity<Level2Model>().HasData(level4.Level2);
    //modelBuilder.Entity<Level3Model>().HasData(level4.Level3);
    modelBuilder.Entity<Level4Model>().HasData(level4);
  }

  private Level4Model CreateData()
  {
    var baseId = Guid.Parse("4f4305bb-17ab-4a42-a1b2-f706573fa850");
    var level2Id = Guid.Parse("18262137-dd04-4977-93cf-f2698ae7d900");
    var level3Id = Guid.Parse("324cdcbf-6486-4e62-81c4-65196a6f52ca");
    var level4Id = Guid.Parse("8f0cf5b8-9420-4441-ab6a-e25a78fd738e");

    var baseModel = new BaseModel
    {
      Id = baseId,
      Name = "Base Name",
      Description = "Base Description",
      BaseProperty = "Base Property",
      Status = Status.Approved
    };

    var level2 = new Level2Model
    {
      Id = level2Id,
      Name = "Level2 Name",
      Description = "Level2 Description",
      Level2Property = "Level2 Property",
      Status = Status.Approved,
      Base = baseModel
    };
    
    var level3 = new Level3Model
    {
      Id = level3Id,
      Name = "Level3 Name",
      Description = "Level3 Description",
      Level3Property = "Level3 Property",
      Status = Status.Approved,
      Level2 = level2
    };
    
    var level4 = new Level4Model
    {
      Id = level4Id,
      Name = "Level4 Name",
      Description = "Level4 Description",
      Level4Property = "Level4 Property",
      Status = Status.Approved,
      Level2 = level2,
      Level3 = level3
    };

    return level4;
  }
}