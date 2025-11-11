using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model;

namespace LiftDataIntegration.Data.Interface
{
  public interface IBuildingData
    {
        public int  AddBuilding(BuildingEntity building);

    }
}
