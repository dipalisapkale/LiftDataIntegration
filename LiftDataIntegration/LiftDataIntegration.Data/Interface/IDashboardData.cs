using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Response;
using Microsoft.VisualBasic;

namespace LiftDataIntegration.Data.Interface
{
  public  interface IDashboardData
    {
        public GetDashboardEntity GetDashboard();
        public GetDashboardSummaryResponse GetDashboardSummary(string RunDate);
        public List<DailyTrendResponse> GetDailyTrend(int Day);
    }
}
