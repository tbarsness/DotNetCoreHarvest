using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestBaseModel
    {
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}