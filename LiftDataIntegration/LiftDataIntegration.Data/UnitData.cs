using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
    public class UnitData : IUnitData
    {
        public readonly IDataConnect _dataConnect;
        public UnitData(IDataConnect dataConnect)
        {
            _dataConnect = dataConnect;


        }
        public List<GetUnitEntity> GetUnit(int id)
        {
            List<GetUnitEntity> listentity = new List<GetUnitEntity>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetUnit"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UnitId", id));
                    var dt = _dataConnect.GetDataTable(cmd);

                    listentity = dt.AsEnumerable()
                          .Select(row => new GetUnitEntity
                          {
                              UnitId = row.Field<int>("UnitId"),
                              EquipmentNo = row.Field<string>("EquipmentNo"),
                              BuildingId = row.Field<int>("BuildingId"),
                              UnitType = row.Field<string>("UnitType"),
                              NumberOfFloors = row.Field<int>("NumberOfFloors"),
                              PremiumStatus = row.Field<string>("PremiumStatus"),
                              IsLinkable = row.Field<bool>("IsLinkable"),                              
                              RouteNo = row.Field<string>("RouteNo"),

                          }).ToList();

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return listentity;

        }

        public int UpdateUnit(UpdateUnitEntity entity)
        {
            int i = 1;
            try
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUnit"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UnitId", entity.UnitId));
                    cmd.Parameters.Add(new SqlParameter("@BuildingId", entity.BuildingId));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentNo", entity.EquipmentNo));
                    cmd.Parameters.Add(new SqlParameter("@UnitDisplayName", entity.UnitDisplayName));
                    cmd.Parameters.Add(new SqlParameter("@UnitType", entity.UnitType));
                    cmd.Parameters.Add(new SqlParameter("@ProductId", entity.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@NumberOfFloors", entity.NumberOfFloors));
                    cmd.Parameters.Add(new SqlParameter("@PremiumStatus", entity.PremiumStatus));                                        
                    cmd.Parameters.Add(new SqlParameter("@RouteNo", entity.RouteNo));
                    cmd.Parameters.Add(new SqlParameter("@DateInstalled", entity.DateInstalled));


                    _dataConnect.ExecuteSqlQuery(cmd);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return i;


        }
        public int ChangeStatusOfUnit(ChangeStatusOfUnitEntity entity)
        {
            int i = 1;
            try
            {

                using (SqlCommand cmd = new SqlCommand("ChangeStatusofUnit"))
                {
                    cmd.CommandType=CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UnitId", entity.UnitId));
                    cmd.Parameters.Add(new SqlParameter("@IsEnable", entity.IsEnable));
                    _dataConnect.ExecuteSqlQuery(cmd);

                }
            }
            catch (Exception)
            {

                throw;
            }
            return i;


        }
    }
}
