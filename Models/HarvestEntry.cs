using System;

namespace Paynter.Harvest.Models
{
    /// <summary>
    /// Day entry given by the Harvest API. Some properties are not available in non-daily resources.
    /// </summary>
    public class HarvestEntryResponseFormat {
        //[JsonProperty("day_entry")]
        public HarvestEntryResponseFormatInner[] Inner { get; set; }
    }
    public class HarvestEntryResponseFormatInner {
        public HarvestEntry Entry { get; set; }
    }
    public class HarvestEntry : HarvestBaseModel {
        public int id { get; set; }
        public string notes { get; set; }
        public DateTime spent_at { get; set; }
        public decimal hours { get; set; }
        public int user_id { get; set; }
        public int project_id { get; set; }
        public int task_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool adjustment_record { get; set; }
        public DateTime? timer_started_at { get; set; }
        public bool is_closed { get; set; }
        public bool is_billed { get; set; }
    }
    
}



