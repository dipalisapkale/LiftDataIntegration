using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
   public class equipmenttypeavalibility
    {

        [JsonPropertyName("passenger")]
        public int Passenger { get; set; }
        [JsonPropertyName("panoramic")]
        public int Panoramic { get; set; }

        [JsonPropertyName("freight")]
        public int Freight { get; set; }




    }
}
