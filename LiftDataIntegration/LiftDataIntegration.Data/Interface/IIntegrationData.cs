using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiftDataIntegration.Entity.Model;
using ClosedXML.Excel;

namespace LiftDataIntegration.Data.Interface
{
 public   interface IIntegrationData
    {
        public int SaveIntegrationData(IXLWorksheet worksheet);

        public int SaveUnitRunData(IXLWorksheet worksheet);

    }
}
