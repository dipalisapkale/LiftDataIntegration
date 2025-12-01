using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Data.Interface
{
    public interface IContractData
    {
        public List<GetContractEntity> GetContracts(int id);
        public int ChangeStatusOfContract(ChangeStatusOfContractEntity entity);
    }
}
