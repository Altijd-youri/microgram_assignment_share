using RabbitMQ.Client;

namespace Cuniculus.Test;

[TestClass]
public class CuniculusOptionsTest
{
    [TestMethod]
    public void DefaultOptions_AreSet()
    {
        var result = new CuniculusOptions("Bunnies", "European");

        Assert.AreEqual("localhost", result.HostName);
        Assert.AreEqual(5672, result.Port);
        Assert.AreEqual("guest", result.Password);
        Assert.AreEqual("guest", result.UserName);
    }
    
    [TestMethod]
    public void Constructor_setsChannelOptions()
    {
        var result = new CuniculusOptions("Bunnies", "European");

        Assert.AreEqual("Bunnies", result.ExchangeName);
        Assert.AreEqual("European", result.QueueName);
    }
    
    [TestMethod]
    public void CreateFactory_DefaultOptions_AreUsed()
    {
        var sut = new CuniculusOptions("Bunnies", "European");

        var result = (ConnectionFactory) sut.CreateFactory();
        
        Assert.AreEqual(5672, result.Endpoint.Port);
        Assert.AreEqual("localhost", result.Endpoint.HostName);
        Assert.AreEqual("guest", result.Password);
        Assert.AreEqual("guest", result.UserName);
    }
    
    [TestMethod]
    public void CreateFactory_CustomOptions_AreUsed()
    {
        var sut = new CuniculusOptions("Bunnies", "European")
        {
            Password = "SecretRabbitAgents",
            UserName = "Rabbit007",
            HostName = "123.245.12.1",
            Port = 15400
        };

        var result = (ConnectionFactory) sut.CreateFactory();
        
        Assert.AreEqual(15400, result.Endpoint.Port);
        Assert.AreEqual("123.245.12.1", result.Endpoint.HostName);
        Assert.AreEqual("SecretRabbitAgents", result.Password);
        Assert.AreEqual("Rabbit007", result.UserName);
    }
}