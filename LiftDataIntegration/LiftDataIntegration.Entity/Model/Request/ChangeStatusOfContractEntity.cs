using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Request
{
   public class ChangeStatusOfContractEntity
    {
        [JsonPropertyName("contractId")]
        public int ContractId { get; set; }
        [JsonPropertyName("isEnable")]
        public bool IsEnable { get; set; }
    }
}
