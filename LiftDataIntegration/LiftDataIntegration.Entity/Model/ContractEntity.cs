using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    /// <summary>
    /// contract Entity classes
    /// </summary>
    class ContractEntity
    {

        public int ContractId { get; set; }
        public int  UnitId { get; set; }
        public int  CustomerId { get; set; }
        public string ContractNumber { get; set; }
        public string  ContractTypeCode { get; set; }

        public DateTime ContractDate { get; set; }
        public DateTime ContractExpiryDate { get; set; }
        public bool Elite { get; set; }
        public DateTime EliteSubscriptionDate { get; set; }

       public DateTime EliteNonSubscriptionDate { get; set; }

        public DateTime NISExpirationDate { get; set; }

        public bool MPDFlag { get; set; }

        public bool  EcallFlag { get;set; }

        public bool  REIEnabled { get; set; }

        public bool ActiveFlag { get; set; }
    }
}
