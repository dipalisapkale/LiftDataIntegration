using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Request
{
   public class UpdateBuildingEntity
    {
        [JsonPropertyName("buildingId")]
        public int BuildingId { get; set; }
        [JsonPropertyName("buildingName")]
        public string BuildingName { get; set; }
        [JsonPropertyName("houseNo")]
        public string HouseNo { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("stateProvince")]
        public string StateProvince { get; set; }
        [JsonPropertyName("countryCode")]

        public string CountryCode { get; set; }
        [JsonPropertyName("buildingNo")]

        public string BuildingNo { get; set; }
        [JsonPropertyName("buildingAddress")]
        public string BuildingAddress { get; set; }
        [JsonPropertyName("siteId")]
        public int SiteId { get; set; }
    }
}
