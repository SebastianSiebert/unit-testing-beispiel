using AutoFixture;
using AutoFixture.AutoMoq;

namespace Beispiel.Anwendung.Test;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    public AutoMoqDataAttribute() : base(() => new Fixture().Customize(new AutoMoqCustomization()))
    {
        
    }
}