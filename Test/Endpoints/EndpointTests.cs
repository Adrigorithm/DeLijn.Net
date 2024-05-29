using DeLijn.Net.App.Api.Client;
using DeLijn.Net.App.Api.Client.Config;
using DeLijn.Net.App.Entities;

namespace DeLijn.Net.Test.Endpoints;

[TestClass]
public class EndpointTests
{
    private static DeLijnClient _deLijnClient = default!;

    [AssemblyInitialize]
    public static void DeLijnClient_Ctor_ConfigFound(TestContext context)
    {
        var path = "../../../../secrets";
        var config = DeLijnConfig.FromStream(File.OpenRead(path));
        
        Assert.IsNotNull(config, $"Config file {path} could not be loaded");

        _deLijnClient = new(config);
    }

    [TestMethod]
    public async Task DeLijnClient_GetEndpoint()
    {
        IReadOnlyList<Entity> entities = [];
        
        try
        {
            entities = await _deLijnClient.GetAllEntitiesAsync();
        }
        catch (Exception e)
        {
            Assert.Fail($"Couldn't fetch entities: ", e);
        }

        Assert.IsTrue(entities.Count > 0, "The response did not countain any entities or the parsing failed");
    }
}