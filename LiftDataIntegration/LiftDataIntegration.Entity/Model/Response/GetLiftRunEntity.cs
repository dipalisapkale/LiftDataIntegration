using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
  public  class GetLiftRunEntity
    {
        [JsonPropertyName("runid")]
        public int RunID { get; set; }
        [JsonPropertyName("equipmentno")]
        public string EquipmentNo { get; set; }
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("start")]
        public string Start { get; set; }
        [JsonPropertyName("end")]
        public string End { get; set; }
        [JsonPropertyName("floors")]
        public int Floors { get; set; }
        [JsonPropertyName("stops")]
        public int Stops { get; set; }
    }

}
