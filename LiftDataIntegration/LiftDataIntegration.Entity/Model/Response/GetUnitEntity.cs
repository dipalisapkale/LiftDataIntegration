using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
   public class GetUnitEntity
    {


        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }

        [JsonPropertyName("equipmentNo")]
        public string EquipmentNo { get; set; }

        [JsonPropertyName("buildingId")]
        public int BuildingId { get; set; }

        [JsonPropertyName("unitType")]
        public string UnitType { get; set; }

        [JsonPropertyName("numberOfFloors")]
        public int NumberOfFloors { get; set; }
        [JsonPropertyName("premiumStatus")]
        public string PremiumStatus { get; set; }
        [JsonPropertyName("isLinkable")]
        public bool IsLinkable { get; set; }

        [JsonPropertyName("otisOne")]
        public bool OtisOne { get; set; }

        [JsonPropertyName("routeNo")]
        public string RouteNo { get; set; }

    }
}
