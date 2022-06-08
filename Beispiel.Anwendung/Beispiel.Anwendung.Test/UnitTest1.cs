using AutoFixture;
using Beispiel.Anwendung.Model;

namespace Beispiel.Anwendung.Test;

public class UnitTest1
{
  [Fact]
  public void TestFunktioniert()
  {
    Assert.True(true);
  }
  
  [Fact]
  public void Test()
  {
    // Arrange
    const string description = "Description";
    
    var fixture = new Fixture();
    fixture.Customize<Level4Model>(e =>
        e.Without(p => p.Level2).With(p => p.Description, description));
    
    var model = fixture.Create<Level4Model>();
    
    // Act
    
    // Assert
    Assert.Equal(description, model.Description);
    Assert.Null(model.Level2);
  }
}