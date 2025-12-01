using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Request
{
    public class UpdateUnitEntity
    {


        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }
        [JsonPropertyName("buildingId")]
        public int BuildingId { get; set; }

        [JsonPropertyName("equipmentNo")]
        public string EquipmentNo { get; set; }
        [JsonPropertyName("unitDisplayName")]
        public string UnitDisplayName { get; set; }

        [JsonPropertyName("unitType")]
        public string UnitType { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("numberOfFloors")]
        public int NumberOfFloors { get; set; }

        [JsonPropertyName("premiumStatus")]
        public string PremiumStatus { get; set; }

        [JsonPropertyName("routeNo")]
        public string RouteNo { get; set; }

        [JsonPropertyName("dateInstalled")]
        public DateTime DateInstalled { get; set; }






    }
}