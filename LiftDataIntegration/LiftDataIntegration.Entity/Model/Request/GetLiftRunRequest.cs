using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Request
{
   public class GetLiftRunRequest
    {
        [JsonPropertyName("equipmentno")]
        public string EquipmentNo { get; set; }
        [JsonPropertyName("date")]
        public  DateTime?  Date  { get; set; }

    }
}
