using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Util;
using FluentValidation;

namespace Beispiel.Anwendung.Services;

public class UpdateCommand<TContract, TEntity> : IUpdateCommand<TContract, TEntity>
    where TContract : class
    where TEntity : class
{
    private readonly IDbContext _dbContext;
    private readonly IMapper<TContract, TEntity> _mapper;
    private readonly IValidator<TEntity> _validator;
    private readonly ITranslation _translation;

    public UpdateCommand(IDbContext dbContext, IMapper<TContract, TEntity> mapper, IValidator<TEntity> validator, ITranslation translation)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        _validator = validator;
        _translation = translation;
    }
    
    public async Task<TEntity> UpdateAsync(Guid id, TContract contract)
    {
        if (contract is null) throw new ArgumentNullException(nameof(contract));
        
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);

        if (entity is null) throw new EntityNotFoundException(_translation.EntityNotFoundMessage);

        entity = _mapper.Map(contract, entity);

        var result = await _validator.ValidateAsync(entity, strategy => strategy.IncludeAllRuleSets().IncludeRulesNotInRuleSet());
        if (!result.IsValid) throw new ValidationFailedException(_translation.ValidationFailedMessage);

        await _dbContext.SaveChangesAsync();

        return entity;
    }
}