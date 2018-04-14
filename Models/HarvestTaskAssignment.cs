using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models {
    public class HarvestTaskAssignmentResponseFormat {
        [JsonProperty("task_assignment")]
        public HarvestTaskAssignment TaskAssignment { get; set; }
    }
    public class HarvestTaskAssignment {
        public int Id { get; set; }

        [JsonProperty("task_id")]
        public int TaskId { get; set; }
        public bool Billable { get; set; }
        public bool Deactivated { get; set; }

        [JsonProperty("project_id")]
        public int ProjectId { get; set; }

        [JsonProperty("hourly_rate")]
        public float? HourlyRate { get; set; }
        public float? Budget { get; set; }
        public decimal? Estimate { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public HarvestTask Task { get; set; }

    }
}