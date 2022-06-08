using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;

namespace Beispiel.Anwendung.Test.Moq;

// Aufgabe 5
public class UpdateCommandTest
{
  [Theory(Skip = "Schreibe prüfung"), AutoMoqData]
  public async Task UpdateAsync_ContractIsNull_ShouldThrowException(UpdateCommand<Level4Contract, Level4Model> sut, Guid id)
  {
    // ToDo Prüfe das ArgumentNullException geschmissen wird
    // Tipp Assert.ThrowsAsync<>
  }

  [Theory, AutoMoqData]
  public async Task UpdateAsync_EntityNotFound_ShouldThrowException()
  {
    // ToDo Prüfe das wenn kein Model in der DB gefunden wird, eine EntityNotFoundException mit richtiger Nachricht geschmissen wird
    // Arrange

    // Act

    // Assert
  }
  
  [Theory, AutoMoqData]
  public async Task UpdateAsync_HasValidationErrors_ShouldThrowException()
  {
    // ToDo Prüfe das wenn die Validierung Fehlschlägt, eine ValidationFailedException mit richtiger Nachricht geschmissen wird.
    // Prüfe dabei auch, dass SaveChangeAsync nicht aufgerufen wird
    // Tipp ValidationResult.IsValid ist false, wenn ValidationResult.Errors (Liste) Einträge enthält
    // Arrange

    // Act

    // Assert
  }
  
  [Theory, AutoMoqData]
  public async Task UpdateAsync_RunsCorrectly()
  {
    // ToDo Prüfe, dass die UpdateAsync Methode durchläuft, prüfe dabei folgende Bedingunge
    // 1. Return Wert der Map Methode ist gleich den Return Wert der UpdateAsync Methode
    // 2. Das Map mit dem richtigen Contract und Model aufgerufen wurde
    // 3. Das SaveChangesAsync aufgerufen wurde
    // Arrange

    // Act

    // Assert
  }
}