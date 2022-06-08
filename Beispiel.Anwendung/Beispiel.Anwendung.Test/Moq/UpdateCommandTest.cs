using Beispiel.Anwendung.Contract;
using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;
using Beispiel.Anwendung.Util;
using FluentValidation;
using FluentValidation.Results;

namespace Beispiel.Anwendung.Test.Moq;

public class UpdateCommandTest
{
  [Theory, AutoMoqData]
  public async Task UpdateAsync_ContractIsNull_ShouldThrowException(UpdateCommand<Level4Contract, Level4Model> sut, Guid id)
  {
    // Split
    var act = () => sut.UpdateAsync(id, null);
    await Assert.ThrowsAsync<ArgumentNullException>("contract", act);

    // Single line
    await Assert.ThrowsAsync<ArgumentNullException>("contract", () => sut.UpdateAsync(id, null));
  }

  [Theory, AutoMoqData]
  public async Task UpdateAsync_EntityNotFound_ShouldThrowException(
    [Frozen] Mock<ITranslation> translationMock,
    [Frozen] Mock<IDbContext> dbContextMock,
    UpdateCommand<Level4Contract, Level4Model> sut, 
    Guid id,
    Level4Contract contract,
    string errorMessage)
  {
    // Arrange
    dbContextMock.Setup(e => e.Set<Level4Model>().FindAsync(It.IsAny<object[]>())).ReturnsAsync((Level4Model) null);
    translationMock.Setup(e => e.EntityNotFoundMessage).Returns(errorMessage);

    // Act
    var result = await Assert.ThrowsAsync<EntityNotFoundException>(() => sut.UpdateAsync(id, contract));

    // Assert
    Assert.Equal(errorMessage, result.Message);
  }
  
  [Theory, AutoMoqData]
  public async Task UpdateAsync_HasValidationErrors_ShouldThrowException(
    [Frozen] Mock<ITranslation> translationMock,
    [Frozen] Mock<IDbContext> dbContextMock,
    [Frozen] Mock<IValidator<Level4Model>> validatorMock,
    UpdateCommand<Level4Contract, Level4Model> sut, 
    Guid id,
    Level4Contract contract,
    Level4Model model,
    ValidationResult validationResult,
    string errorMessage)
  {
    // Arrange
    dbContextMock.Setup(e => e.Set<Level4Model>().FindAsync(It.IsAny<object[]>())).ReturnsAsync(model);
    translationMock.Setup(e => e.ValidationFailedMessage).Returns(errorMessage);
    // Dies funktioniert nicht, da diese Methode eine Extension Methode ist
    //validatorMock.Setup(e => e.ValidateAsync(It.IsAny<Level4Model>(), It.IsAny<Action<ValidationStrategy<Level4Model>>>(), It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);
    validatorMock.SetReturnsDefault(Task.FromResult(validationResult));

    // Act
    var result = await Assert.ThrowsAsync<ValidationFailedException>(() => sut.UpdateAsync(id, contract));

    // Assert
    Assert.Equal(errorMessage, result.Message);
    dbContextMock.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
  }
  
  [Theory, AutoMoqData]
  public async Task UpdateAsync_RunsCorrectly(
    [Frozen] Mock<IDbContext> dbContextMock,
    [Frozen] Mock<IMapper<Level4Contract, Level4Model>> mapperMock,
    UpdateCommand<Level4Contract, Level4Model> sut, 
    Guid id,
    Level4Contract contract,
    Level4Model modelDb,
    Level4Model modelMap)
  {
    // Arrange
    dbContextMock.Setup(e => e.Set<Level4Model>().FindAsync(It.IsAny<object[]>())).ReturnsAsync(modelDb);
    mapperMock.Setup(e => e.Map(It.IsAny<Level4Contract>(), It.IsAny<Level4Model>())).Returns(modelMap);

    // Act
    var result = await sut.UpdateAsync(id, contract);

    // Assert
    Assert.Equal(modelMap, result);
    mapperMock.Verify(e => e.Map(contract, modelDb));
    dbContextMock.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()));
  }
}