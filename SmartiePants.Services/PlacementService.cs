using AutoMapper;
using SmartiePants.Core.Resources;
using SmartiePants.Core.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SmartiePants.Services
{
    public class PlacementService : IPlacementService
    {
        private readonly IHttpClientService _httpClientService;
        private const string BASE_URL = "https://services.api.unity.com/monetize/v0";
        private readonly Dictionary<string, string> _headers;

        public PlacementService(IHttpClientService httpClientService, IConfiguration configuration)
        {
            _httpClientService = httpClientService ?? throw new ArgumentNullException(nameof(httpClientService));
            _headers = new Dictionary<string, string>
            {
                { "Authorization", $"Basic {configuration.GetValue<string>("UnityAPI:Token")}" }
            };
        }

        public async Task<List<PlacementDto>> CreatePlacementsAsync(PlacementsResourceParameters data)
        {
            CreateParamsForRequest(data, out Dictionary<string, string> queryParams, out string url);
            HttpResponseMessage httpResponse = await _httpClientService.PostAsync(url, _headers, data.Placements, queryParams);
            string responseString = await ConvertResponse(httpResponse);
            List<PlacementDto> placements = JsonConvert.DeserializeObject<List<PlacementDto>>(responseString);
            return placements;
        }

        public async Task<List<PlacementDto>> UpdatePlacementsAsync(PlacementsResourceParameters data)
        {
            CreateParamsForRequest(data, out Dictionary<string, string> queryParams, out string url);
            HttpResponseMessage httpResponse = await _httpClientService.PutAsync(url, _headers, data.Placements, queryParams);
            string responseString = await ConvertResponse(httpResponse);
            List<PlacementDto> placements = JsonConvert.DeserializeObject<List<PlacementDto>>(responseString);
            return placements;
        }

        private static void CreateParamsForRequest(PlacementsResourceParameters data, out Dictionary<string, string> queryParams, out string url)
        {
            queryParams = null;
            if (data.Dryrun != null)
            {
                queryParams = new Dictionary<string, string>
                {
                    { "dryrun", data.Dryrun.ToString() }
                };
            }
            url = $"{BASE_URL}/projects/{data.ProjectId}/{data.StoreName}/adunits/{data.AdUnitId}/placements";
        }

        private async Task<string> ConvertResponse(HttpResponseMessage httpResponseMessage)
        {
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                return responseString;
            }
            else
            {
                string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                UnityApiError error = JsonConvert.DeserializeObject<UnityApiError>(responseString);
                throw new Exception(error?.Detail != null ? error.Detail : httpResponseMessage.ReasonPhrase);
            }
        }
    }
}