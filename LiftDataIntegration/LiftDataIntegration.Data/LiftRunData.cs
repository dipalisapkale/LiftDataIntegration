using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace LiftDataIntegration.Data
{
   public class LiftRunData:ILiftRunData
    {
        public readonly IDataConnect _dataConnect;
        public LiftRunData(IDataConnect dataConnect)
        {
            _dataConnect=dataConnect;
        }
        public List<GetLiftRunEntity> GetLiftRun(GetLiftRunRequest request)
        {
          
            List<GetLiftRunEntity> list = new List<GetLiftRunEntity>();

            try
            {
                using (SqlCommand cmd = new SqlCommand("GetLiftRun"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                

                    cmd.Parameters.AddWithValue("@EquipmentNo",
                string.IsNullOrEmpty(request.EquipmentNo) ? (object)DBNull.Value : request.EquipmentNo);

                    cmd.Parameters.AddWithValue("@RunDate",
                        request.Date == null || request.Date == DateTime.MinValue ? (object)DBNull.Value : request.Date);

                    var dt = _dataConnect.GetDataTable(cmd);
                    {
                        //getLiftRunEntity.RunID= Convert.ToInt32(dt.Rows[0]["RunId"]);
                        //getLiftRunEntity.EquipmentNo = Convert.ToString(dt.Rows[0]["EquipmentNo"]);
                        //getLiftRunEntity.Date = Convert.ToDateTime(dt.Rows[0]["EquipmentNo"]);

                        //TimeSpan RunStartTime = (TimeSpan)dt.Rows[0]["RunStartTime"];
                        //string start = RunStartTime.ToString(@"hh\:mm");
                        //getLiftRunEntity.Start= start;

                        //TimeSpan RunEndTime = (TimeSpan)dt.Rows[0]["RunEndTime"];
                        //string End = RunEndTime.ToString(@"hh\:mm");
                        //getLiftRunEntity.End = End;


                        list = dt.AsEnumerable()
                         .Select(row => new GetLiftRunEntity
                         {
                             RunID = row.Field<int>("RunId"),
                             EquipmentNo = row.Field<string>("EquipmentNo"),
                             Date = row.Field<DateTime>("RunDate"),
                             Start = row.Field<TimeSpan>("RunStartTime").ToString(@"hh\:mm"),
                             End = row.Field<TimeSpan>("RunStartTime").ToString(@"hh\:mm"),
                             Floors= row.Field<int>("NoOfFloor"),
                             Stops = row.Field<int>("NoOfStops"),
                         }).ToList();
                    }
                }


            }
			catch (Exception ex )
			{

				throw ex;
			}
            return list ;
        }
        

    }
}
