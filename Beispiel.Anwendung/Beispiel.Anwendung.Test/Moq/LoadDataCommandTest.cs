using Beispiel.Anwendung.Interfaces;
using Beispiel.Anwendung.Model;
using Beispiel.Anwendung.Services;
using MockQueryable.Moq;
using Moq.EntityFrameworkCore;

namespace Beispiel.Anwendung.Test.Moq;

public class LoadDataCommandTest
{
  [Theory, AutoMoqData]
  public async Task LoadDataNoTracking([Frozen] Mock<IDbContext> dbContextMock, LoadDataCommand<BaseModel> sut, List<BaseModel> modelList)
  {
    // Arrange
    dbContextMock.Setup(e => e.SetQueryable<BaseModel>()).Returns(modelList.BuildMock());

    // Act
    var result = await sut.LoadDataNoTrackingAsync();
    
    // Assert
    Assert.Equal(modelList.Count, result.Count);
  }
  
  [Theory, AutoMoqData]
  public async Task LoadData([Frozen] Mock<IDbContext> dbContextMock, LoadDataCommand<BaseModel> sut, List<BaseModel> modelList)
  {
    // Arrange
    dbContextMock.Setup(e => e.Set<BaseModel>()).ReturnsDbSet(modelList);

    // Act
    var result = await sut.LoadDataAsync();
    
    // Assert
    Assert.Equal(modelList.Count, result.Count);
    Assert.All(result, model => modelList.Any(e => e.Id == model.Id));
  }
}