using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Service.Interface
{
    public interface IContractService
    {
        public List<GetContractEntity> GetContract(int id);
        public int ChangeStatusOfContract(ChangeStatusOfContractEntity entity);
    }
}
