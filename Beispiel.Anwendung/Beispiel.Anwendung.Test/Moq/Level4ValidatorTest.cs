using Beispiel.Anwendung.Services;
using FluentValidation.TestHelper;

namespace Beispiel.Anwendung.Test.Moq;

// Aufgabe 3
public class Level4ValidatorTest
{
    // Test ist vollständig. Nach Aufgabe 1 "Skip" entfernen und der Test sollte grün werden
    [Theory(Skip = "Test Lauffähig sobald Aufgabe 1 erledigt"), AutoMoqData]
    public async Task Validation_Name_ShouldNotHaveValidationErrors(Level4Validator sut, Level4Model model)
    {
        // Arrange
        
        // Act
        var result = await sut.TestValidateAsync(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(e => e.Name);
    }
    
    // Erster Validierungsfehler für Property Name sollte geschmissen werden (Name == null).
    // Es sollte auf die richtige Fehler Nachricht geprüft werden.
    // Siehe Assert wie auf Fehler geprüft wird
    [Theory, AutoMoqData]
    public async Task Validation_NameEmpty_ShouldHaveValidationErrors()
    {
        // Assert
        //result.ShouldHaveValidationErrorFor(e => e.Name).WithErrorMessage(errorMessage);
    }
    
    // Zweiter Validierungsfehler für Property Name sollte geschmissen werden (Name.Length > 50)
    // Es sollte verifiziert werden, ob die Fehler Nachricht mit dem richtigen Parameter aufgerufen wird
    [Theory, AutoMoqData]
    public async Task Validation_NameToLong_ShouldHaveValidationErrors()
    {
    }
}