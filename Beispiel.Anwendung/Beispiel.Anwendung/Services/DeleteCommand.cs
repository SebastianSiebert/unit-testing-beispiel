using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Util;

namespace Beispiel.Anwendung.Services;

public class DeleteCommand<TEntity>
  where TEntity : class
{
  private readonly IDbContext _dbContext;
  private readonly ITranslation _translation;
  
  public DeleteCommand(IDbContext dbContext, ITranslation translation)
  {
    _dbContext = dbContext;
    _translation = translation;
  }
  
  public async Task DeleteAsync(Guid id)
  {
    var entity = await _dbContext.Set<TEntity>().FindAsync(id);
    if (entity is null) throw new EntityNotFoundException(_translation.EntityNotFoundMessage);

    _dbContext.Remove(entity);

    await _dbContext.SaveChangesAsync();
  }
}