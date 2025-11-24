using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Service.Interface
{
   public interface IGetUnitService
    {
        public List<GetUnitEntity> GetUnit(int id);
    }
}
