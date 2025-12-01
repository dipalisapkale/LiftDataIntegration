using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Data.Interface
{
  public  interface IUserData
    {
        public int AddUser(AddUserEntity entity);
        public List<GetUserEntity> GetUser(int id);
        public UserAuthenticationResponse AuthenticateUser(UserAuthenticationRequest request);
    }
}
