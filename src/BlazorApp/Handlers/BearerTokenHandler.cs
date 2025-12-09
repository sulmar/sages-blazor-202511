using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.IO.Pipes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace BlazorApp.Handlers;

public class BearerTokenHandler : DelegatingHandler
{    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = "{your-token}";

        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}

