using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ValueTypesInModels.Tests;

public class ModelTests
{
    private WebApplicationFactory<Program> factory;

    [SetUp]
    public void Setup()
    {
        factory = new WebApplicationFactory<Program>();
    }

    [TearDown]
    public void TearDown()
    {
        factory.Dispose();
    }

    [Test]
    public async Task NoErrorForMissingRequiredField()
    {
        using var httpClient = factory.CreateClient();
        var response = await httpClient.PostAsJsonAsync("/Sample", new { Optional = "Green" });

        response.Should().BeSuccessful();
        response
            .Content.ReadAsStringAsync()
            .Result.Should()
            .Be("""{"required":"Red","optional":"Green"}""");
    }

    [Test]
    public async Task MissingOptionalFieldFallsBackToDefault()
    {
        using var httpClient = factory.CreateClient();
        var response = await httpClient.PostAsJsonAsync("/Sample", new { Required = "Green" });

        response.Should().BeSuccessful();
        response
            .Content.ReadAsStringAsync()
            .Result.Should()
            .Be("""{"required":"Green","optional":"Red"}""");
    }
}
