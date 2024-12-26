using System.Net;
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
    public async Task ErrorForMissingRequiredField()
    {
        using var httpClient = factory.CreateClient();
        var response = await httpClient.PostAsJsonAsync("/Sample", new { Optional = "Green" });

        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }

    [Test]
    public async Task MissingOptionalFieldHasNoValue()
    {
        using var httpClient = factory.CreateClient();
        var response = await httpClient.PostAsJsonAsync("/Sample", new { Required = "Green" });

        response.Should().BeSuccessful();
        response
            .Content.ReadAsStringAsync()
            .Result.Should()
            .Be("""{"required":"Green","optional":null}""");
    }
}
