using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
   public class DashboardData:IDashboardData
    {
        public readonly IDataConnect _dataConnect;
        public DashboardData(IDataConnect dataConnect) 
        {
            _dataConnect = dataConnect;
        }
        public GetDashboardEntity GetDashboard()
        {

            GetDashboardEntity entity = new GetDashboardEntity();

            try
			{
                using (SqlCommand cmd = new SqlCommand("sp_GetDashboardData"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                   var ds = _dataConnect.GetDataSet(cmd);

                    
                    entity.TotalBuildings = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalBuildings"]);
                    entity.TotalUnits = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalUnits"]);
                    entity.TotalActiveContracts = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalActiveContracts"]);
                    entity.TotalUnitRuns = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalUnitRuns"]);

                    List<liftusage> liftusages = new List<liftusage>();

                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        liftusage liftusage = new liftusage();

                        liftusage.UnitId= Convert.ToInt32(ds.Tables[1].Rows[i]["UnitId"]);
                        liftusage.EquipmentNo = Convert.ToString(ds.Tables[1].Rows[i]["EquipmentNo"]);
                        liftusage.BuildingId = Convert.ToInt32(ds.Tables[1].Rows[i]["BuildingId"]);
                        liftusage.BuildingName = Convert.ToString(ds.Tables[1].Rows[i]["BuildingName"]);
                        liftusage.TotalRun = Convert.ToInt32(ds.Tables[1].Rows[i]["TotalRun"]);
                        liftusages.Add(liftusage);

                       
                    }
                    equipmenttypeavalibility availability = new equipmenttypeavalibility();
                    availability.Passenger = Convert.ToInt32(ds.Tables[2].Rows[0]["passengerCount"]);
                    availability.Panoramic = Convert.ToInt32(ds.Tables[2].Rows[0]["parasonicCount"]);
                    availability.Freight = Convert.ToInt32(ds.Tables[2].Rows[0]["freightCount"]);

                    entity.liftUsages = liftusages;
                    entity.equipmenttypeavalibility = availability;
                }
                }
            catch (Exception ex)
			{

				throw ex;
			}
            return entity;
        }
		
    }
}
