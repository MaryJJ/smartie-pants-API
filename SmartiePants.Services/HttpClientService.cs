using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        public async Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers = null,
                                                        Dictionary<string, string> parameters = null)
        {
            CreateClient(url, headers, parameters, out HttpRequestMessage request, out HttpClient client, HttpMethod.Get);
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> headers, object data,
                                                         Dictionary<string, string> parameters = null)
        {
            CreateClient(url, headers, parameters, out HttpRequestMessage request, out HttpClient client, HttpMethod.Post);
            CreateContent(data, request);
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }

        public async Task<HttpResponseMessage> PutAsync(string url, Dictionary<string, string> headers, object data,
                                                 Dictionary<string, string> parameters = null)
        {
            CreateClient(url, headers, parameters, out HttpRequestMessage request, out HttpClient client, HttpMethod.Put);
            CreateContent(data, request);
            HttpResponseMessage response = await client.SendAsync(request);
            return response;
        }

        private static void CreateContent(object data, HttpRequestMessage request)
        {
            string body = JsonConvert.SerializeObject(data,
                                                      new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Formatting = Formatting.Indented });
            request.Content = new StringContent(body, Encoding.UTF8, "application/json");
        }

        private void CreateClient(string url, Dictionary<string, string> headers, Dictionary<string, string> parameters,
                                  out HttpRequestMessage request, out HttpClient client, HttpMethod httpMethod)
        {
            string requestUri = url;
            if (parameters != null)
            {
                requestUri = QueryHelpers.AddQueryString(url, parameters);
            }
            request = new HttpRequestMessage(httpMethod, requestUri);
            foreach (KeyValuePair<string, string> header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            client = _httpClientFactory.CreateClient();
        }
    }
}