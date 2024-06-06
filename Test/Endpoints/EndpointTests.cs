using DeLijn.Net.App.Api.Client;
using DeLijn.Net.App.Api.Client.Config;
using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Response;

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
    public async Task DeLijnClient_GetCoreEndpointsEndpoint_Test()
    {
        IReadOnlyList<Link> endpoints = [];

        try
        {
#pragma warning disable CS0618 // library coverage
            endpoints = await _deLijnClient.GetCoreEndpointsAsync();
#pragma warning restore CS0618 // library coverage
        }
        catch (Exception e)
        {
            Assert.Fail($"Couldn't fetch entities: ", e);
        }
    }

    [TestMethod]
    public async Task DeLijnClient_GetAllEntitiesEndpoint_Test()
    {
        IReadOnlyList<Entity>? entities = [];

        try
        {
            entities = await _deLijnClient.GetAllEntitiesAsync();
        }
        catch (Exception e)
        {
            Assert.Fail($"Couldn't fetch entities: ", e);
        }
    }

    [TestMethod]
    public async Task DeLijnClient_GetDiversionsEndpoint_Test()
    {
        (IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults)? diversions = null;

        try
        {
            diversions = await _deLijnClient.GetDiversionsAsync();
        }
        catch (Exception e)
        {
            Assert.Fail($"Couldn't fetch entities: ", e);
        }
    }

    [TestMethod]
    [DataRow(4, 407043)] // Valid stop
    [DataRow(100, 407043)] // Invalid entity
    [DataRow(1, 123456789)] // Invalid stop
    public async Task DeLijnClient_GetDiversionsByStopEndpoint_Test(short entityId, int stopId)
    {
        (IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults) diversions;

        try
        {
            diversions = await _deLijnClient.GetDiversionsByStopAsync(entityId, stopId);
        }
        catch (Exception e)
        {
            Assert.Fail($"Couldn't fetch entities: ", e);
        }
    }
}