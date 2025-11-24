using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Service.Interface
{
   public interface IBuildingService
    {

        public List<GetBuildingResponse> GetBuildings(int id);
        public int PostBuilding (PostBuildingEntity entity);
    }
}
