using Beispiel.Anwendung.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Beispiel.Anwendung.Services;

public class LoadDataCommand<TEntity>
  where TEntity : class
{
  private readonly IDbContext _dbContext;
  
  public LoadDataCommand(IDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public async Task<List<TEntity>> LoadDataNoTrackingAsync() => await _dbContext.SetQueryable<TEntity>().ToListAsync();

  public async Task<List<TEntity>> LoadDataAsync() => await _dbContext.Set<TEntity>().ToListAsync();

}