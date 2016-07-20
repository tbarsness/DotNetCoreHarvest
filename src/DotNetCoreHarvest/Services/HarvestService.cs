using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Paynter.Harvest.Configuration;
using Paynter.Harvest.Models;

namespace Paynter.Harvest.Services
{
    public class HarvestService
    {
        private HarvestOptions _options;
        private string _base64Auth;
        private HttpClient _httpClient;
        private ILogger<HarvestService> _logger;

        public HarvestService(IOptions<HarvestOptions> options, ILogger<HarvestService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public string Base64Auth 
        { 
            get
            {
                if(string.IsNullOrEmpty(_base64Auth))
                {
                    var authString = Encoding.ASCII.GetBytes($"{_options.UserName}:{_options.Password}");
                    _base64Auth = System.Convert.ToBase64String(authString);
                }

                return _base64Auth;
            }
        }

        public HttpClient HttpClient 
        { 
            get
            {
                if(_httpClient == null)
                {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri($"{_options.ApiUrl}");    
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Base64Auth}");
                }

                return _httpClient;
            }
        }

        public async Task<dynamic> WhoAmI()
        {
            var response = await HttpClient.GetAsync($"/account/who_am_i");
            var content = await response.Content.ReadAsStringAsync();
            
            if(response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Error sending message to Harvest API");
                // throw new WitAiServiceException("Error sending message to Wit.AI Message API", response, contents);
            }

            return JsonConvert.DeserializeObject<dynamic>(content);
        }

        public async Task<IEnumerable<HarvestProject>> Projects()
        {
            var response = await HttpClient.GetAsync($"/projects");
            var content = await response.Content.ReadAsStringAsync();

            if(response.StatusCode != HttpStatusCode.OK)
            {
                _logger.LogError("Error sending message to Harvest API");
                // throw new WitAiServiceException("Error sending message to Wit.AI Message API", response, contents);
            }

            _logger.LogDebug("Harvest project response {@content}", content);

                var settings = new JsonSerializerSettings
                 {
                     TypeNameHandling = TypeNameHandling.All
                 };
            IEnumerable<HarvestProjectResponseFormat> projects = JsonConvert.DeserializeObject<IEnumerable<HarvestProjectResponseFormat>>(content, settings);
            return projects.Select(u => u.Project).ToList();
        }

    }
}