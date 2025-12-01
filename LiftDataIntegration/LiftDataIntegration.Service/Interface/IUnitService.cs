using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Service.Interface
{
   public interface IUnitService
    {
        public List<GetUnitEntity> GetUnit(int id);
        public int UpdateUnit(UpdateUnitEntity entity);
        public int ChangeStatusOfUnit(ChangeStatusOfUnitEntity entity);
    }
}
