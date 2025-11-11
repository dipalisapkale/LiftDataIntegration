using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model;
using LiftDataIntegration.Infrastructure.Interface;
using ClosedXML.Excel;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
    /// <summary>
    /// class for data integration
    /// </summary>
    public class IntegrationData : IIntegrationData
    {
        public readonly IDataConnect _dataConnect;

        public IntegrationData(IDataConnect dataConnect)

        {
            _dataConnect = dataConnect;
        }
        public int SaveIntegrationData(IXLWorksheet worksheet)
        {
            int i = 0;

            try
            {
                string query = "SaveIntegrationData";
               

                foreach (var row in worksheet.RowsUsed().Skip(1))
                {
                    SqlCommand cmd = new SqlCommand(query);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@SiteNo", row.Cell(1).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@CountryCode", row.Cell(2).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@SiteName", row.Cell(3).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@BuildingNo", row.Cell(4).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@EquipmentNo", row.Cell(5).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@ContractTypeCode", row.Cell(6).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@UnitType", row.Cell(7).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@IsRType", Convert.ToBoolean(row.Cell(8).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@ContractNumber", row.Cell(9).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@ContractDate", Convert.ToDateTime(row.Cell(10).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@CustomerNo", row.Cell(11).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@CustomerName", row.Cell(12).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@CustomerNickname", row.Cell(13).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@CAddress", row.Cell(14).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@IsLinked", Convert.ToBoolean(row.Cell(15).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@RouteNo", row.Cell(16).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@DateInstalled", Convert.ToDateTime(row.Cell(17).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@EtypeUnit", Convert.ToBoolean(row.Cell(18).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@EtypeUnitSubscriptionDate", Convert.ToDateTime(row.Cell(19).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@ContractExpiryDate", Convert.ToDateTime(row.Cell(20).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@REnabled", Convert.ToBoolean(row.Cell(21).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@MFlag", Convert.ToBoolean(row.Cell(22).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@EFlag", Convert.ToBoolean(row.Cell(23).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@NExpirationDate", Convert.ToDateTime(row.Cell(24).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@NumberOfFloors", Convert.ToInt32(row.Cell(25).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@PhoneNumber", row.Cell(26).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@Email", row.Cell(27).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@PremiumStatus", row.Cell(28).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@UnitDisplayName", row.Cell(29).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@OOne", Convert.ToBoolean(row.Cell(30).GetString())));
                    cmd.Parameters.Add(new SqlParameter("@BuildingName", row.Cell(31).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@HouseNo", row.Cell(32).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@Street", row.Cell(33).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@City", row.Cell(34).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@PostalCode", row.Cell(35).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@StateProvince", row.Cell(36).GetString()));                    
                    cmd.Parameters.Add(new SqlParameter("@UnitNo", row.Cell(37).GetString()));
                    cmd.Parameters.Add(new SqlParameter("@BuildingAddress", row.Cell(38).GetString()));

                    _dataConnect.ExecuteSqlQuery(cmd);
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
