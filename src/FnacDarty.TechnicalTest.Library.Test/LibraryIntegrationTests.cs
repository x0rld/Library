using System.Net;
using System.Net.Http.Json;
using FnacDarty.TechnicalTest.Library.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace FnacDarty.TechnicalTest.Library.Test;

public class LibraryIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public LibraryIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task LibraryController_AddBook_accept_json_and_return_ok()
    {
        var client = _factory.CreateClient();
        var bookToAdd = new AddBookRequest("Title", "Author");
        var response = await client.PostAsJsonAsync("/api/library/addBook", bookToAdd);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}