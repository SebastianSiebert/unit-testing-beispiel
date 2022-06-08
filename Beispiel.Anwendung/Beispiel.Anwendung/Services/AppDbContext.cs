using System.Text.Json;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Beispiel.Anwendung.Services;

public class AppDbContext : DbContext, IDbContext
{
  public DbSet<BaseModel> BaseModels { get; set; }
  public DbSet<Level2Model> Level2Models { get; set; }
  public DbSet<Level3Model> Level3Models { get; set; }
  public DbSet<Level4Model> Level4Models { get; set; }
  
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

  public IQueryable<TEntity> SetQueryable<TEntity>() where TEntity : class => Set<TEntity>().AsNoTracking();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    var valueComparer = new ValueComparer<List<string>>(
      (c1, c2) => c1.SequenceEqual(c2),
      c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
      c => c.ToList());
    modelBuilder
      .Entity<Level4Model>()
      .Property(e => e.ListProperty)
      .HasConversion(v => JsonSerializer.Serialize(v, new JsonSerializerOptions()), 
        v => JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions()), valueComparer);
    var model = CreateData();
    modelBuilder.Entity<BaseModel>().HasData(model.Base);
    modelBuilder.Entity<Level2Model>().HasData(model.Level2);
    modelBuilder.Entity<Level3Model>().HasData(model.Level3);
    modelBuilder.Entity<Level4Model>().HasData(model.Level4);
  }

  private dynamic CreateData()
  {
    var baseId = Guid.Parse("4f4305bb-17ab-4a42-a1b2-f706573fa850");
    var level2Id = Guid.Parse("18262137-dd04-4977-93cf-f2698ae7d900");
    var level3Id = Guid.Parse("324cdcbf-6486-4e62-81c4-65196a6f52ca");
    var level4Id = Guid.Parse("8f0cf5b8-9420-4441-ab6a-e25a78fd738e");

    var model = new
    {
      Base = new
      {
        Id = baseId,
        Name = "Base Name",
        Description = "Base Description",
        BaseProperty = "Base Property",
        Status = Status.Approved
      },
      Level2 = new
      {
        Id = level2Id,
        Name = "Level2 Name",
        Description = "Level2 Description",
        Level2Property = "Level2 Property",
        IsCondition = true,
        Status = Status.Approved,
        BaseId = baseId
      },
      Level3 = new
      {
        Id = level3Id,
        Name = "Level3 Name",
        Description = "Level3 Description",
        Level3Property = "Level3 Property",
        Number = 42,
        Status = Status.Approved,
        Level2Id = level2Id
      },
      Level4 = new
      {
        Id = level4Id,
        Name = "Level4 Name",
        Description = "Level4 Description",
        Level4Property = "Level4 Property",
        ListProperty = new List<string>
        {
          "Value 1",
          "Value 2"
        },
        Status = Status.Approved,
        Level2Id = level2Id,
        Level3Id = level3Id
      }
    };

    return model;
  }
}