using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Spreadsheet;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
    public class BuildingData : IBuildingData
    {
        public readonly IDataConnect _dataConnect;

        public BuildingData(IDataConnect dataConnect)
        {
            _dataConnect = dataConnect;
        }
        public List<GetBuildingResponse> GetBuildings(int id)
        {
            List<GetBuildingResponse> list = new List<GetBuildingResponse>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetBuildings"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@BuildingID", id));
                    var dt = _dataConnect.GetDataTable(cmd);

                    list = dt.AsEnumerable()
                           .Select(row => new GetBuildingResponse
                           {
                               BuildingId = row.Field<int>("BuildingId"),
                               BuildingName = row.Field<string>("BuildingName"),
                               City = row.Field<string>("City"),
                               HouseNo = row.Field<string>("HouseNo"),
                               Street = row.Field<string>("Street"),
                               PostalCode = row.Field<string>("PostalCode"),
                               State = row.Field<string>("StateProvince"),
                               CountryCode = row.Field<string>("CountryCode"),
                               BuildingNo = row.Field<string>("BuildingNo"),
                               BuildingAddress = row.Field<string>("BuildingAddress")
                           }).ToList();

                }
            }
            catch (Exception ex)
            {

                throw ex;


            }

            return list;
        }
        public int PostBuilding(PostBuildingEntity entity)
        {
            int i = 1;
            try
            {
                using (SqlCommand command = new SqlCommand("PostBuilding"))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.Add(new SqlParameter("@BuildingName", entity.BuildingName));
                    command.Parameters.Add(new SqlParameter("@HouseNo", entity.HouseNo));
                    command.Parameters.Add(new SqlParameter("@Street", entity.Street));
                    command.Parameters.Add(new SqlParameter("@City", entity.City));
                    command.Parameters.Add(new SqlParameter("@PostalCode", entity.PostalCode));
                    command.Parameters.Add(new SqlParameter("@StateProvince", entity.StateProvince));
                    command.Parameters.Add(new SqlParameter("@CountryCode", entity.CountryCode));
                    command.Parameters.Add(new SqlParameter("@BuildingNo", entity.BuildingNo));
                    command.Parameters.Add(new SqlParameter("@BuildingAddress", entity.BuildingAddress));
                    command.Parameters.Add(new SqlParameter("@SiteId", entity.SiteId));

                    _dataConnect.ExecuteSqlQuery(command);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return i;
        }



        public int UpdateBuilding(UpdateBuildingEntity Entity)
        {
            int i = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("UpdateBuilding"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@BuildingId", Entity.BuildingId));
                    command.Parameters.Add(new SqlParameter("@BuildingName", Entity.BuildingName));
                    command.Parameters.Add(new SqlParameter("@HouseNo", Entity.HouseNo));
                    command.Parameters.Add(new SqlParameter("@Street", Entity.Street));
                    command.Parameters.Add(new SqlParameter("@City", Entity.City));
                    command.Parameters.Add(new SqlParameter("@PostalCode", Entity.PostalCode));
                    command.Parameters.Add(new SqlParameter("@StateProvince", Entity.StateProvince));
                    command.Parameters.Add(new SqlParameter("@CountryCode", Entity.CountryCode));
                    command.Parameters.Add(new SqlParameter("@BuildingNo", Entity.BuildingNo));
                    command.Parameters.Add(new SqlParameter("@BuildingAddress", Entity.BuildingAddress));
                    command.Parameters.Add(new SqlParameter("@SiteId", Entity.SiteId));

                    _dataConnect.ExecuteSqlQuery(command);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return i;

        }
        public int ChangeStatus(ChangeStatusEntity statusEntity)
        {
            int i = 0;
            try
            {
                using (SqlCommand command = new SqlCommand("ChangeStatus"))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@BuildingId", statusEntity.BuildingId));
                    command.Parameters.Add(new SqlParameter("@IsEnable", statusEntity.IsEnable));
                    _dataConnect.ExecuteSqlQuery(command);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return i;
        }



    }

}



