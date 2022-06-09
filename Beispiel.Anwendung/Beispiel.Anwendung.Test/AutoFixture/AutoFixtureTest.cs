using AutoFixture;

namespace Beispiel.Anwendung.Test.AutoFixture;

public class AutoFixtureTest
{
  [Fact(Skip = "Something went wrong")]
  public void Customization_Test()
  {
    // Arrange
    const string description = "Description";
    
    var fixture = new Fixture();
    // ToDo Füge Konfiguration der Fixture hinzu
    
    var model = fixture.Create<Level4Model>();
    
    // Act
    
    // Assert
    Assert.Equal(description, model.Description);
    Assert.Equal(5, model.ListProperty.Count);
    Assert.InRange(model.Level3.Number, 20, 39);
    Assert.Null(model.Level2);
  }

  [Fact(Skip = "Ohoh")]
  public void Freeze_Test1()
  {
    // Arrange
    var model1 = new Level4Model();
    var model2 = new Level4Model();
    
    // Act
    
    // Assert
    Assert.Equal(model1, model2);
    Assert.Equal(model1.Name, model2.Name);
    Assert.Equal(model1.Description, model2.Description);
    Assert.Equal(model1.Status, model2.Status);
  }

  [Theory(Skip = "Ohoh"), AutoData]
  public void Freeze_Test2(BaseModel model1, BaseModel model2)
  {
    // Arrange
    // Act
    // Assert
    Assert.Equal(model1, model2);
    Assert.Equal(model1.Name, model2.Name);
    Assert.Equal(model1.Description, model2.Description);
    Assert.Equal(model1.Status, model2.Status);
  }
}