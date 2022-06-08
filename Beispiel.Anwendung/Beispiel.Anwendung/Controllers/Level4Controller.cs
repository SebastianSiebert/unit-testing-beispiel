using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Beispiel.Anwendung.Controllers;

[ApiController]
[Route("[controller]")]
public class Level4Controller : ControllerBase
{
  private readonly IDbContext _dbContext;
  private readonly IExpressionMapper<Level4Model, Level4Contract> _contractMapper;

  public Level4Controller(IDbContext dbContext, IExpressionMapper<Level4Model, Level4Contract> contractMapper)
  {
    _dbContext = dbContext;
    _contractMapper = contractMapper;
  }

  [HttpGet]
  public async Task<IActionResult> GetAsync()
  {
    var query = await _dbContext.Set<Level4Model>()
      .Select(_contractMapper.Map())
      .ToListAsync();

    return Ok(query);
  }
}