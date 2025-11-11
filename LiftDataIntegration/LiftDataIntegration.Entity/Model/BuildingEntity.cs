using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
  public  class BuildingEntity
    {

        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public string HouseNo { get; set; }
        public string street { get; set; }
        public string City { get; set; }

        public string PostalCode { get; set; }
        public string StateProvince { get; set; }

        public string CountryCode { get; set; }

        public DateTime DateAdded { get; set; }
       

    }
}
