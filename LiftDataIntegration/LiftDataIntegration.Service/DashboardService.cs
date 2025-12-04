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
  public class DashboardService:IDashboardService

    {
        public readonly IDashboardData _dashboardData;
        public DashboardService(IDashboardData dashboardData)
        {
            _dashboardData=dashboardData;
        }
        public GetDashboardEntity GetDashboard()
        {
             var result = _dashboardData.GetDashboard();
            return result;
        }
    }
}
