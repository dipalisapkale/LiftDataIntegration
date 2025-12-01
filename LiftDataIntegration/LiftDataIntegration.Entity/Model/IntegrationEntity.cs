using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    public class IntegrationEntity
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StateProvince { get; set; }
        public string CountryCode { get; set; }


        public DateTime DateAdded { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNickname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


      
        public int UnitId { get; set; }
        
        public string EquipmentNo { get; set; }
        public string UnitDisplayName { get; set; }
        public string UnitType { get; set; }
        public string ProductId { get; set; }
        public string NumberOfFloors { get; set; }
        public string PremiumStatus { get; set; }
        public bool IsLinkable { get; set; }        
        public string RouteNo { get; set; }
        public string DateInstalled { get; set; }
        public DateTime DateModified { get; set; }

        public int ContractId { get; set; }
       
        public string ContractNumber { get; set; }
        public string ContractTypeCode { get; set; }

        public DateTime ContractDate { get; set; }
        public DateTime ContractExpiryDate { get; set; }

        public int RunId { get; set; }      
        public int RunNo { get; set; }

        public DateTime RunDate { get; set; }

        public DateTime RunStartTime { get; set; }
        public DateTime RunEndTime { get; set; }
        public decimal SpeedOfRun { get; set; }

        public int StartFloorNo { get; set; }

        public int EndFloorNo { get; set; }
        public int NoOfFloor { get; set; }
        public int CallingFloor { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
