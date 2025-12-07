using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model.Response;

namespace LiftDataIntegration.Service.Interface
{
  public interface IDashboardService
    {
        public GetDashboardEntity GetDashboard();
        public GetDashboardSummaryResponse GetDashboardSummary(string RunDate);
        public  List<DailyTrendResponse> GetDailyTrend(int Day);
    }
}
