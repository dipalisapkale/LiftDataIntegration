using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
namespace LiftDataIntegration.Data.Interface
{
   public interface IBuildingData
    {
        public List<GetBuildingResponse> GetBuildings(int id);
         public int PostBuilding (PostBuildingEntity entity);  

        public int UpdateBuilding(UpdateBuildingEntity Entity);

        public int ChangeStatus(ChangeStatusEntity statusEntity);
    }
}
