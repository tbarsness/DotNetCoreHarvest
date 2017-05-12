using System;
using Newtonsoft.Json;

namespace Paynter.Harvest.Models
{
    public class HarvestUserResponseFormat
    {
        public HarvestUser User { get; set; }
    }
    public class HarvestUser : HarvestBaseModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }
        public string TimeZone { get; set; }
         
        [JsonProperty("is_contractor")]
        public bool IsContractor { get; set; }

        public string PhoneNumber { get; set; }
        
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

    }
}