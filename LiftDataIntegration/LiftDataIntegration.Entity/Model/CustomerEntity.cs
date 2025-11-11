using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model
{
    class CustomerEntity
    {

        public int CustomerId  { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNickname { get; set; }
        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public string StateProvince { get; set; }
        public string CountryCode { get; set; }
    }
}
