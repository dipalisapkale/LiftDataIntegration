using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model;
using ClosedXML.Excel;

namespace LiftDataIntegration.Service
{
    public interface IIntegrationService
    {
        public int SaveIntegrationService(IXLWorksheet worksheet);
        public int SaveRunUnitData(IXLWorksheet worksheet);
    }
}
