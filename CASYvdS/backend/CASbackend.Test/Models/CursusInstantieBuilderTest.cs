using System.Reflection;
using CASbackend.Models;

namespace CASbackend.Test.Models;

[TestClass]
public class CursusInstantieBuilderTest
{
    [TestMethod]
    public void StaticGet_ReturnInstance()
    {
        var result = CursusInstantieBuilder.Get();
        
        Assert.IsInstanceOfType(result, typeof(CursusInstantieBuilder));
    }
    
    [TestMethod]
    public void HasNotPublicConstructor()
    {
        var publicConstructors = 
            typeof(CursusInstantieBuilder).GetConstructors(BindingFlags.Instance | BindingFlags.Public);

        var result = publicConstructors.Length;
        
        Assert.AreEqual(0, result);
    }
    
    [TestMethod]
    public void PropertiesArePrivate()
    {
        var publicProperties =
            typeof(CursusInstantieBuilder).GetProperties(BindingFlags.Instance | BindingFlags.Public);

        var result = publicProperties.Length;
        
        Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void Build_ThrowExceptionWhenPropertiesAreMissing()
    {
        var invalidBuild = CursusInstantieBuilder.Get().AddTitel("Cursus titel");

        var code = () => invalidBuild.Build();

        Assert.ThrowsException<ArgumentException>(code);
    }
    
    [TestMethod]
    public void Build_ReturnsCurusInstantieObject_WithCorrectProperties()
    {
        var validBuild = CursusInstantieBuilder.Get()
            .AddTitel("Cursus titel")
            .AddCursusCode("CODE")
            .AddDuur(5)
            .AddStartDatum(new DateTime(2022, 10, 10));

        var result = validBuild.Build();
        
        Assert.IsTrue(
            result.StartDatum.Year == 2022 && result.StartDatum.Month == 10 && result.StartDatum.Day == 10 &&
            result.Cursus.Code == "CODE" && result.Cursus.Titel == "Cursus titel" && result.Cursus.Duur == 5
        );
    }
}