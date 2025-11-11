using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using LiftDataIntegration.Data.Interface;
using ClosedXML.Excel;

namespace LiftDataIntegration.Service
{
   public class IntegrationService:IIntegrationService
    {
        public readonly IIntegrationData _integrationData;
        public IntegrationService(IIntegrationData integrationData)

        {

            _integrationData = integrationData;
        }
        public int SaveIntegrationService(IXLWorksheet worksheet)

        {
            var result = _integrationData.SaveIntegrationData(worksheet);
            return result;

        }

    }
}
