using AutoFixture;

namespace Beispiel.Anwendung.Test.AutoFixture;

public class AutoFixtureTest
{
  [Fact]
  public void Customization_Test()
  {
    // Arrange
    const string description = "Description";
    
    var fixture = new Fixture();
    fixture.Customize<Level3Model>(e => e
        .With(p => p.Number, () => new Random().Next(20, 40))
    );
    fixture.Customize<Level4Model>(e => e
        .With(p => p.ListProperty, () => fixture.CreateMany<string>(5).ToList())
        .With(p => p.Description, description)
        .Without(p => p.Level2)
    );
    
    var model = fixture.Create<Level4Model>();
    
    // Act
    
    // Assert
    Assert.Equal(description, model.Description);
    Assert.Equal(5, model.ListProperty.Count);
    Assert.InRange(model.Level3.Number, 20, 39);
    Assert.Null(model.Level2);
  }

  [Fact]
  public void Freeze_Test1()
  {
    // Arrange
    var fixture = new Fixture();

    var model1 = fixture.Freeze<Level4Model>();
    var model2 = fixture.Create<Level4Model>();
    
    // Act
    
    // Assert
    Assert.Equal(model1, model2);
    Assert.Equal(model1.Name, model2.Name);
    Assert.Equal(model1.Description, model2.Description);
    Assert.Equal(model1.Status, model2.Status);
  }

  [Theory, AutoData]
  public void Freeze_Test2([Frozen] BaseModel model1, BaseModel model2)
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