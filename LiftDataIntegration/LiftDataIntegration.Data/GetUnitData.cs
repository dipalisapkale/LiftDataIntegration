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
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
   public class GetUnitData:IGetUnitData
    {
        public readonly IDataConnect _dataConnect;
        public GetUnitData(IDataConnect dataConnect)
        {
            _dataConnect= dataConnect;


        }
        public List<GetUnitEntity> GetUnit(int id)
        {
            List<GetUnitEntity> listentity= new List<GetUnitEntity>();
            try
			{
                using (SqlCommand cmd = new SqlCommand("GetUnit"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@UnitId", id));
                    var dt= _dataConnect.GetDataTable(cmd);

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
                              OtisOne = row.Field<bool>("OtisOne"),
                              RouteNo = row.Field<string>("RouteNo"),
                            
                          }).ToList();

                }

			}
			catch (Exception)
			{

				throw;
			}
            return listentity;

        }
    }
}
