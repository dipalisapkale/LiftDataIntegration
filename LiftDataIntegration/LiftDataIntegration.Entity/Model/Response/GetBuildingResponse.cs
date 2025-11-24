using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
  public  class GetBuildingResponse
    {
        [JsonPropertyName("buildingId")]
        public int BuildingId { get; set; }
        [JsonPropertyName("buildingName")]
        public string BuildingName { get; set; }
        [JsonPropertyName("city")]
        public string City { get; set; }
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
        [JsonPropertyName("houseNo")]
        public string HouseNo { get; set; }
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [JsonPropertyName("buildingNo")]
        public string BuildingNo { get; set; }
        [JsonPropertyName("buildingAddress")]
        public string BuildingAddress { get; set; }
    }
}
