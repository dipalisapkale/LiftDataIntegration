using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;


namespace LiftDataIntegration.Infrastructure.Interface
{
    public interface IDataConnect : IDisposable
    {
        public int ExecuteSqlQuery(SqlCommand objCmd);
        public int ExecuteScalarSqlQuery(SqlCommand objCmd);
        public DataSet GetDataSet(SqlCommand objCmd);
        public DataTable GetDataTable(SqlCommand objCmd);

    }

}
