using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;

namespace Beispiel.Anwendung.Test.Moq;

// Aufgabe 2
public class LoadDataCommandTest
{
  [Theory(Skip = "Keleiguration für Mock erstellen"), AutoMoqData]
  public async Task LoadDataNoTracking(LoadDataCommand<BaseModel> sut, List<BaseModel> modelList)
  {
    // Arrange
    // ToDo Configuriere Mock um richtige Daten zurück zu geben

    // Act
    var result = await sut.LoadDataNoTrackingAsync();
    
    // Assert
    Assert.Equal(modelList.Count, result.Count);
  }
  
  [Theory(Skip = "Keleiguration für Mock erstellen"), AutoMoqData]
  public async Task LoadData(LoadDataCommand<BaseModel> sut, List<BaseModel> modelList)
  {
    // Arrange
    // ToDo Configuriere Mock um richtige Daten zurück zu geben

    // Act
    var result = await sut.LoadDataAsync();
    
    // Assert
    Assert.Equal(modelList.Count, result.Count);
    Assert.All(result, model => modelList.Any(e => e.Id == model.Id));
  }
}