using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestLogTimeRequest
    {
        public string Id { get; set; }
        public double Hours { get; set; }
        public string Notes { get; set; }
        
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [JsonProperty("spent_at")]
        public DateTime SpentAt { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }
    }
}