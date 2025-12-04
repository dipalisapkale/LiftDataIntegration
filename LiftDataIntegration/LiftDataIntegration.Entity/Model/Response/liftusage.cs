using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
   public class liftusage
    {
        [JsonPropertyName("unitId")]
        public int UnitId {  get; set; }

        [JsonPropertyName("equipmentNo")]
        public string EquipmentNo { get; set; }

        [JsonPropertyName("buildingId")]
        public int BuildingId { get; set; }

        [JsonPropertyName("buildingName")]
        public string BuildingName { get; set; }

        [JsonPropertyName("totalRun")]
        public int TotalRun { get; set; }

    }
}
