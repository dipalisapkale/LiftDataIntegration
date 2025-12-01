using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;

namespace LiftDataIntegration.Service
{
 public class UnitService:IUnitService
    {
        public readonly IUnitData _Unitdata;
        public UnitService(IUnitData Unitdata)
        {
            _Unitdata = Unitdata;
        }
        public List<GetUnitEntity> GetUnit(int id)
        {
            var result= _Unitdata.GetUnit(id);
            return result;
        }

        public int UpdateUnit(UpdateUnitEntity entity)
        {
            var result = _Unitdata.UpdateUnit(entity);
            return result;
        }

        public int ChangeStatusOfUnit(ChangeStatusOfUnitEntity entity)
        {
            var result = _Unitdata.ChangeStatusOfUnit(entity);
            return result;

        }
    }
}
