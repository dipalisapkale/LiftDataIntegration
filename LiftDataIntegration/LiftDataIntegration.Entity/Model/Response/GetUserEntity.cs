using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LiftDataIntegration.Entity.Model.Response
{
   public class GetUserEntity
    {


        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("userName")]
        public string UserName { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("userFirstName")]
        public string UserFirstName { get; set; }
        [JsonPropertyName("userLastName")]
        public string UserLastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }
        [JsonPropertyName("customerId")]
        public int CustomerId { get; set; }
        [JsonPropertyName("isCustomerUser")]
        public bool IsCustomerUser { get; set; }
    }
}
