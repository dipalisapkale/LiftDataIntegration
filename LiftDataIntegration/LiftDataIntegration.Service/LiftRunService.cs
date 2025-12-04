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
  public  class LiftRunService:ILiftRunService
    {
        public readonly ILiftRunData _liftRunData;
        public LiftRunService(ILiftRunData liftRunData)
        {
            _liftRunData=liftRunData;
        }
        public List<GetLiftRunEntity> GetLiftRun(GetLiftRunRequest request)
        { 
            var result = _liftRunData.GetLiftRun(request);

            return result;
        }
    }
}
