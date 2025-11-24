using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using LiftDataIntegration.Data;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model;
using LiftDataIntegration.Entity.Model.Request;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;

namespace LiftDataIntegration.Service
{
    public class BuildingService : IBuildingService
    {
        public readonly IBuildingData _buildingData;

        public BuildingService(IBuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public List<GetBuildingResponse> GetBuildings(int id)
        {
            var result = _buildingData.GetBuildings(id);
            return result;
        }
        public int PostBuilding(PostBuildingEntity entity)
        {
            var result = _buildingData.PostBuilding(entity);
            return result;
        }


    }

}