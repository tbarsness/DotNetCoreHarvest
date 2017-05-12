using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestTaskAssignmentResponseFormat
    {
        [JsonProperty("task_assignment")]
        public HarvestTaskAssignment TaskAssignment { get; set; }
    }
    public class HarvestTaskAssignment
    {
        public string Id { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }
        public bool Billable { get; set; }
        public bool Deactivated { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public HarvestTask Task { get; set; }

    }
}