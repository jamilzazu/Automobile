﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Automobile.MVC.Services
{
    public class HttpClientAuthorizationDelegatingHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ////var authorizationHeader = _user.ObterHttpContext().Request.Headers["Authorization"];

            //if (!string.IsNullOrEmpty(authorizationHeader))
            //{
            //    request.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            //}

            //var token = _user.ObterUserToken();

            //if (token != null)
            //{
            //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //}

            return base.SendAsync(request, cancellationToken);
        }
    }
}