using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
    public class UserData : IUserData
    {
        public readonly IDataConnect _dataConnect;
        public UserData(IDataConnect dataConnect)
        {

            _dataConnect = dataConnect;
        }

        public int AddUser(AddUserEntity entity)
        {
            int i = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("AddUser"))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@UserName", entity.UserName));
                    command.Parameters.Add(new SqlParameter("@Password", entity.Password));
                    command.Parameters.Add(new SqlParameter("@UserFirstName", entity.UserFirstName));
                    command.Parameters.Add(new SqlParameter("@UserLastName", entity.UserLastName));
                    command.Parameters.Add(new SqlParameter("@Email", entity.Email));
                    command.Parameters.Add(new SqlParameter("@IsActive", entity.IsActive));
                    command.Parameters.Add(new SqlParameter("@CustomerId", entity.CustomerId));
                    command.Parameters.Add(new SqlParameter("@IsCustomerUser", entity.IsCustomerUser));


                    _dataConnect.ExecuteSqlQuery(command);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return i;
        }
        public List<GetUserEntity> GetUser(int id)
        {
            List<GetUserEntity> list = new List<GetUserEntity>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetUser"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Id", id));
                    var dt = _dataConnect.GetDataTable(cmd);

                    list = dt.AsEnumerable()
                           .Select(row => new GetUserEntity
                           {
                               Id = row.Field<int>("Id"),
                               UserName = row.Field<string>("UserName"),
                               Password = row.Field<string>("Password"),
                               UserFirstName = row.Field<string>("UserFirstName"),
                               UserLastName = row.Field<string>("UserLastName"),
                               Email = row.Field<string>("Email"),
                               IsActive = row.Field<bool>("IsActive"),
                               CustomerId = row.Field<int>("CustomerId"),
                               IsCustomerUser = row.Field<bool>("IsCustomerUser"),

                           }).ToList();

                }
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        public UserAuthenticationResponse AuthenticateUser(UserAuthenticationRequest request)
        {
            UserAuthenticationResponse response = new UserAuthenticationResponse();
            try
            {
                using (SqlCommand cmd = new SqlCommand("UserAuthentication"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UserName",request.UserName));
                    cmd.Parameters.Add(new SqlParameter("@Password", request.Password));
                    var dt = _dataConnect.GetDataTable(cmd);
                   
                    if (dt.Rows.Count > 0)
                    {
                        response.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                        response.UserName = Convert.ToString(dt.Rows[0]["UserName"]);
                        response.Password = Convert.ToString(dt.Rows[0]["Password"]);
                        response.UserFirstName = Convert.ToString(dt.Rows[0]["UserFirstName"]);
                        response.UserLastName = Convert.ToString(dt.Rows[0]["UserLastName"]);
                        response.Email = Convert.ToString(dt.Rows[0]["Email"]);
                        response.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                        response.CustomerId = Convert.ToInt32(dt.Rows[0]["CustomerId"]);
                        response.IsCustomerUser = Convert.ToBoolean(dt.Rows[0]["IsCustomerUser"]);





                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response;
        }
    }
}