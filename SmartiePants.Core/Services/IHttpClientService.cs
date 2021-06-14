using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartiePants.Core.Services
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string url, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null);

        Task<HttpResponseMessage> PostAsync(string url, Dictionary<string, string> headers, object data, Dictionary<string, string> parameters = null);

        Task<HttpResponseMessage> PutAsync(string url, Dictionary<string, string> headers, object data, Dictionary<string, string> parameters = null);
    }
}