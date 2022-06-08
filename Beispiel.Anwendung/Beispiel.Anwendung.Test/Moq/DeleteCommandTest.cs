using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Beispiel.Anwendung.Test.Moq;

public class DeleteCommandTest
{
  [Theory, AutoMoqData]
  public async Task DeleteAsync(
    [Frozen] Mock<IDbContext> dbContextMock,
    DeleteCommand<BaseModel> sut,
    Guid id,
    BaseModel model)
  {
    // Arrange
    dbContextMock.Setup(e => e.Set<BaseModel>().FindAsync(It.IsAny<object>())).ReturnsAsync(model);
    dbContextMock.Setup(e => e.Remove(It.IsAny<BaseModel>())).Returns((EntityEntry<BaseModel>) null);
    
    // Act
    await sut.DeleteAsync(id);
    
    // Assert
    dbContextMock.Verify(e => e.Set<BaseModel>().FindAsync(id));
    dbContextMock.Verify(e => e.Remove(model));
    dbContextMock.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()));
  } 
}