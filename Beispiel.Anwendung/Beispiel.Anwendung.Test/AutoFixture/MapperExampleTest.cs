using Beispiel.Anwendung.Mapper;

namespace Beispiel.Anwendung.Test.AutoFixture;

public class MapperExampleTest
{
    [Theory, AutoData]
    public void MapperExample_MapCorrectly(Level4ContractMapperExample sut, Level4Model model)
    {
        // Arrange

        // Act
        var result = sut.Map(model, null);

        // Assert
        Assert.Equal(model.Id, result.Id);
        Assert.Equal(model.Name, result.Name);
        Assert.Equal(model.Description, result.Description);
        Assert.Equal(model.Level2.Base.BaseProperty, result.BaseProperty);
        Assert.Equal(model.Level2.Level2Property, result.Level2Property);
        Assert.Equal(model.Level3.Level3Property, result.Level3Property);
        Assert.Equal(model.Level4Property, result.Level4Property);
        Assert.Equal(model.Level2.IsCondition, result.IsCondition);
        Assert.Equal(model.Level3.Number, result.Number);
        Assert.Equal(model.ListProperty, result.ListProperty);
        Assert.Equal(model.Status, result.Status);
    }
}