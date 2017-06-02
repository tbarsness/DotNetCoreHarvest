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
using Newtonsoft.Json.Linq;

namespace Paynter.Harvest.Services {
    public class HarvestService {
        private HarvestOptions _options;
        private string _base64Auth;
        private HttpClient _httpClient;
        private ILogger<HarvestService> _logger;

        public HarvestService(IOptions<HarvestOptions> options, ILogger<HarvestService> logger) {
            _options = options.Value;
            _logger = logger;
        }

        public string Base64Auth {
            get {
                if (string.IsNullOrEmpty(_base64Auth)) {
                    var authString = Encoding.ASCII.GetBytes($"{_options.UserName}:{_options.Password}");
                    _base64Auth = System.Convert.ToBase64String(authString);
                }

                return _base64Auth;
            }
        }

        public HttpClient HttpClient {
            get {
                if (_httpClient == null) {
                    _httpClient = new HttpClient();
                    _httpClient.BaseAddress = new Uri($"{_options.ApiUrl}");
                    _httpClient.DefaultRequestHeaders.Accept.Clear();
                    _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    _httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Base64Auth}");
                }

                return _httpClient;
            }
        }

        public async Task<dynamic> WhoAmI() {
            return await GetRequest<dynamic>($"/projects");
        }

        public async Task<IEnumerable<HarvestProject>> Projects() {
            var results = await GetRequest<IEnumerable<HarvestProjectResponseFormat>>($"/projects");
            return results.Select(u => u.Project).ToList();
        }

        public async Task<IEnumerable<HarvestUser>> People() {
            var results = await GetRequest<IEnumerable<HarvestUserResponseFormat>>($"/people");
            return results.Select(u => u.User).ToList();
        }

        public async Task<IEnumerable<HarvestTaskAssignment>> TaskAssignments(string projectId) {
            var results = await GetRequest<IEnumerable<HarvestTaskAssignmentResponseFormat>>($"/projects/{projectId}/task_assignments");
            return results.Select(u => u.TaskAssignment).ToList();
        }

        public async Task<IEnumerable<HarvestTask>> Tasks() {
            var results = await GetRequest<IEnumerable<HarvestTaskResponseFormat>>($"/tasks");
            return results.Select(u => u.Task).ToList();
        }

        public async Task<IEnumerable<HarvestEntry>> Entries(int harvestProjectId) {
            return await Entries(harvestProjectId, new DateTime(2010, 01, 01), DateTime.Now);
        }

        //public async void Entries(int harvestProjectId) {
        public async Task<IEnumerable<HarvestEntry>> Entries(int harvestProjectId, DateTime fromDate, DateTime toDate) {
            //TODO: Fix date range or will break 1/1
            var results = await GetRequest<IEnumerable<JObject>>($"/projects/{harvestProjectId}/entries/?from={fromDate.ToString("yyyyMMdd")}&to={toDate.ToString("yyyyMMdd")}");
            return results.Select(u => u["day_entry"].ToObject<HarvestEntry>()).ToList();
        }

        //public async Task LogTime() {

        //}

        public async Task<TResponseFormat> GetRequest<TResponseFormat>(string url) where TResponseFormat : class {
            var response = await HttpClient.GetAsync(url);

            if (response.StatusCode != HttpStatusCode.OK) {
                _logger.LogError("Error sending message to Harvest API endpoint {endpoint}", url);
                // throw new WitAiServiceException("Error sending message to Wit.AI Message API", response, contents);
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TResponseFormat>(content);
        }


    }
}