using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Data.Interface;
using LiftDataIntegration.Entity.Model.Response;
using LiftDataIntegration.Service.Interface;
using Microsoft.VisualBasic;

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
        public GetDashboardSummaryResponse GetDashboardSummary(string  RunDate) 
        {
            var result = _dashboardData.GetDashboardSummary(RunDate);
            return result;
        }

        public List<DailyTrendResponse> GetDailyTrend(int Day)
        {
            var result = _dashboardData.GetDailyTrend(Day);
            return result;

        }
    }
}
