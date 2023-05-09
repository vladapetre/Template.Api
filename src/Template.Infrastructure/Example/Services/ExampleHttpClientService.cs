using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Infrastructure.Http.Client;

namespace Template.Infrastructure.Example.Services;
internal sealed class ExampleHttpClientService : IHttpClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ExampleHttpClientService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<object> Test()
    {
        var httpClient = _httpClientFactory.CreateClient();

        return await httpClient.SendAsync(new());
    }
}
