using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Request
{
   public class ChangeStatusOfUnitEntity
    {
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }
        [JsonPropertyName("isEnable")]
        public bool IsEnable { get; set; }
    }
}
