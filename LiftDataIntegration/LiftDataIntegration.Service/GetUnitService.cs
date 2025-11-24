using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;

namespace LiftDataIntegration.Service
{
 public class GetUnitService:IGetUnitService
    {
        public readonly IGetUnitData _getUnitdata;
        public GetUnitService(IGetUnitData getUnitdata)
        {
            _getUnitdata = getUnitdata;
        }
        public List<GetUnitEntity> GetUnit(int id)
        {
            var result= _getUnitdata.GetUnit(id);
            return result;
        }
    }
}
