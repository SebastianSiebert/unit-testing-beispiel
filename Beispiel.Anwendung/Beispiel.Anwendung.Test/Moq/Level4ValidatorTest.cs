
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;
using FluentValidation.TestHelper;

namespace Beispiel.Anwendung.Test;

public class Level4ValidatorTest
{
    [Theory, AutoMoqData]
    public async Task Validation_NameEmpty_ShouldHaveValidationErrors([Frozen] Mock<ITranslation> translationMock, Level4Validator sut, Level4Model model, string errorMessage)
    {
        // Arrange
        model.Name = null;
        translationMock.Setup(e => e.NotEmptyMessage).Returns(errorMessage);

        // Act
        var result = await sut.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(e => e.Name).WithErrorMessage(errorMessage);
    }
    
    [Theory, AutoMoqData]
    public async Task Validation_NameToLong_ShouldHaveValidationErrors([Frozen] Mock<ITranslation> translationMock, Level4Validator sut, Level4Model model, string errorMessage)
    {
        // Arrange
        var maxLength = 50;
        model.Name = new string('*', maxLength + 1);
        translationMock.Setup(e => e.MaxLengthMessage(It.IsAny<int>())).Returns(errorMessage);

        // Act
        var result = await sut.TestValidateAsync(model);

        // Assert
        result.ShouldHaveValidationErrorFor(e => e.Name).WithErrorMessage(errorMessage);
        translationMock.Verify(e => e.MaxLengthMessage(maxLength));
    }
    
    [Theory, AutoMoqData]
    public async Task Validation_Name_ShouldNotHaveValidationErrors(Level4Validator sut, Level4Model model)
    {
        // Arrange
        
        // Act
        var result = await sut.TestValidateAsync(model);

        // Assert
        result.ShouldNotHaveValidationErrorFor(e => e.Name);
    }
    
}