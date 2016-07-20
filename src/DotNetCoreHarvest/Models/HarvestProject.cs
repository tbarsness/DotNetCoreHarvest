using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestProjectResponseFormat
    {
        public HarvestProject Project { get; set; }
    }
    public class HarvestProject
    {
        public string Id { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public bool Billable { get; set; }

        [JsonProperty("bill_by")]
        public string BillBy { get; set; }
        
        [JsonProperty("hourly_rate")]
        public double? HourlyRate { get; set; }

        public double? Budget { get; set; }

        [JsonProperty("notify_when_over_budget")]
        public bool NotifyWhenOverBudget { get; set; }

        [JsonProperty("over_budget_notification_percentage")]
        public double? OverBudgetNotificationPercentage { get; set; }

        [JsonProperty("over_budget_notified_at")]
        public string OverBudgetNotifiedAt { get; set; }

        [JsonProperty("show_budget_to_all")]
        public bool ShowBudgetToAll { get; set; }

        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty("starts_on")]
        public DateTime? StartsOn { get; set; }

        [JsonProperty("ends_on")]
        public DateTime? EndsOn { get; set; }
        public decimal? Estimate { get; set; }

        [JsonProperty("estimate_by")]
        public string EstimateBy { get; set; }

        [JsonProperty("hint_earliest_record_at")]
        public DateTime? HintEarliestRecordAt { get; set; }

        [JsonProperty("hint_latest_record_at")]
        public DateTime? HintLatestRecordAt { get; set; }
        public string Notes { get; set; }
    }
}