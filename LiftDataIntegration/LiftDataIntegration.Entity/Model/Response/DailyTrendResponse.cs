using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
  public  class DailyTrendResponse
    {
        [JsonPropertyName("date")]
        public DateTime Date {  get; set; }
        [JsonPropertyName("runs")]
        public int Runs { get; set; }
    }
}
