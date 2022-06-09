using Beispiel.Anwendung.Mapper;

namespace Beispiel.Anwendung.Test.AutoFixture;

public class MapperExampleTest
{
    [Theory(Skip = "Das klappt wohl so nicht"), AutoData]
    public void MapperExample_MapCorrectly(Level4ContractMapperExample sut)
    {
        // Arrange

        // Act
        var result = sut.Map(null, null);

        // Assert
        // ToDo Assert das Attribute dem Mapper enstrepchend gesetzt sind
    }
}