using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Vml.Office;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Infrastructure;
using LiftDataIntegration.Infrastructure.Interface;
using Microsoft.Data.SqlClient;

namespace LiftDataIntegration.Data
{
   public class ContractData:IContractData
    {
        public readonly IDataConnect _dataConnect;
        public ContractData(IDataConnect dataConnect) 
        {
            _dataConnect = dataConnect;
        }

        public List<GetContractEntity> GetContracts(int id)
        {
            List<GetContractEntity> list =new List<GetContractEntity>();
            try
            {
                using (SqlCommand cmd = new SqlCommand("GetContract"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ContractId", id));
                    var dt = _dataConnect.GetDataTable(cmd);
                    list = dt.AsEnumerable()
                           .Select(row => new GetContractEntity
                           {
                               ContractId = row.Field<int>("ContractId"),
                               UnitId = row.Field<int>("UnitId"),
                               CustomerId = row.Field<int>("CustomerId"),
                               ContractNumber = row.Field<string>("ContractNumber"),
                               ContractTypeCode = row.Field<string>("ContractTypeCode"),
                               ContractDate = row.Field<DateTime>("ContractDate"),
                               ContractExpiryDate = row.Field<DateTime>("ContractExpiryDate"),



                           }).ToList();



                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }

        public int ChangeStatusOfContract(ChangeStatusOfContractEntity entity)
        {
            int i = 1;

            try
            {
                using (SqlCommand cmd = new SqlCommand("ChangeStatusOfContract"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ContractId", entity.ContractId));
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
