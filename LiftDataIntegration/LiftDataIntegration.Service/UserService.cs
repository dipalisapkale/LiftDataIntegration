using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using LiftDataIntegration.Data;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;

namespace LiftDataIntegration.Service
{
   
    public class UserService : IUserService
    {
        public readonly IUserData _userData;
        public UserService(IUserData userData)
        
        {
            _userData=userData;


        }
        public int AddUser(AddUserEntity entity)
        {
          var result = _userData.AddUser(entity);
            return result;

        }
        public List<GetUserEntity> GetUser(int id)
        {

            var result= _userData.GetUser(id);
            return result;
        }

        public UserAuthenticationResponse AuthenticateUser(UserAuthenticationRequest request)
        {

            
            var result=_userData.AuthenticateUser(request);
            return result;
        }
    }
}
