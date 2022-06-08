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

  [Fact(Skip = "Test für AutoFixture")]
  public void Test()
  {
    var fixture = new Fixture();
    var model = fixture.Create<Level4Model>();
    
    
    Assert.Null(model.Level2);
  }
}