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
    public class ContractService : IContractService
    {
        public readonly IContractData _contractData;
        public ContractService(IContractData contractData)
        {
            _contractData = contractData;
        }
        public List<GetContractEntity> GetContract(int id)
        {
            var result = _contractData.GetContracts(id);
            return result;
        }
        public int ChangeStatusOfContract(ChangeStatusOfContractEntity entity)
        {
            var result = _contractData.ChangeStatusOfContract(entity);
            return result;
        }
    }

}
