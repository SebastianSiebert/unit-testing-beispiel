namespace Beispiel.Anwendung.Interfaces;

public interface IUpdateCommand<in TContract, TEntity>
    where TContract : class
    where TEntity : class
{
    Task<TEntity> UpdateAsync(Guid id, TContract contract);
}