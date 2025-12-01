using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    /// <summary>
    /// contract Entity classes
    /// </summary>
  public  class GetContractEntity
    {
        [JsonPropertyName("contractId")]
        public int ContractId { get; set; }
        [JsonPropertyName("unitId")]
        public int UnitId { get; set; }
        [JsonPropertyName("customerId")]

        public int CustomerId { get; set; }
        [JsonPropertyName("contractNumber")]
       
        public string ContractNumber { get; set; }
        [JsonPropertyName("contractTypeCode")]
        public string ContractTypeCode { get; set; }
        [JsonPropertyName("ContractDate")]
        public DateTime ContractDate { get; set; }
        [JsonPropertyName("contractExpiryDate")]
        public DateTime ContractExpiryDate { get; set; }
        
    }
}
