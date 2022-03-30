using Automobile.MVC.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace Automobile.MVC.Services
{

    public class AutomobileService : Service
    {
        private readonly HttpClient _httpClient;

        public AutomobileService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.AutomobileUrl);
        }
    }
}