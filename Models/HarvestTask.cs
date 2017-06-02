using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestTaskResponseFormat
    {
        public HarvestTask Task { get; set; }
    }
    public class HarvestTask : HarvestBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deactivated { get; set; }

        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

    }
}