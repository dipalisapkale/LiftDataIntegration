using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
   public class GetDashboardSummaryResponse
    {

        
        [JsonPropertyName("totalbuilding")]
        public int TotalBuilding { get; set; }
        [JsonPropertyName("totallifts")]
        public int TotalLifts { get; set; }
        [JsonPropertyName("runtoday")]
        public int RunToday { get; set; }
        [JsonPropertyName("peakhourtoday")]
        public int PeakHourToday { get; set; }
        [JsonPropertyName("todaypeakrun")]
        public int TodayPeakRun { get; set; }

    }
}
