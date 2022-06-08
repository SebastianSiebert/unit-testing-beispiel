using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;

namespace Beispiel.Anwendung.Test.Moq;

// Aufgabe 4
public class DeleteCommandTest
{
  [Theory(Skip = "Test befüllen"), AutoMoqData]
  public async Task DeleteAsync(
    DeleteCommand<BaseModel> sut,
    Guid id,
    BaseModel model)
  {
    // Arrange
    // ToDo Setup Mocks
    
    // Act
    await sut.DeleteAsync(id);
    
    // Assert
    // Todo Assert that FindAsync was called with given id, remove was called with the model, and that SaveChangesAsync was called
  } 
}