using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
    public class GetDashboardEntity
    {
        [JsonPropertyName("totalBuildings")]
        public int TotalBuildings {  get; set; }
        [JsonPropertyName("totalUnits")]
        public int TotalUnits { get; set; }
        [JsonPropertyName("totalActiveContracts")]
        public int TotalActiveContracts { get; set; }
        [JsonPropertyName("totalUnitRuns")]
        public int TotalUnitRuns { get; set; }
        [JsonPropertyName("liftUsages")]
        public  List<liftusage> liftUsages { get; set; }
        public equipmenttypeavalibility equipmenttypeavalibility { get; set; }

    }
}
