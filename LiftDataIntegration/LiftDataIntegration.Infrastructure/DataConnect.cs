using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using LiftDataIntegration.Infrastructure.Interface;


namespace LiftDataIntegration.Infrastructure
{
    /// <summary>
    /// DB connection class
    /// </summary>
    public class DataConnect : IDataConnect
    {
        // Creating SqlConnection class object.
        public string connectionString;

        private SqlConnection _connection;
        private bool disposed;


        public DataConnect()
        {
            connectionString = Environment.GetEnvironmentVariable("SQLConnectionString");

            _connection = new SqlConnection(connectionString);
        }

        /// <summary>
        /// Finalizes the object instance.
        /// </summary>
        ~DataConnect()
        {
            Dispose(false);
        }

        /// <summary>
        /// Execute Sql Query
        /// </summary>
        /// <param name="objSqlCommand"></param>
        /// <returns></returns>
        public int ExecuteSqlQuery(SqlCommand objSqlCommand)
        {
            int intReturnValue = 0;

            // Opening database connection.
            if (this.OpenDBConnection() == true)
            {
                // Assigning sql query to command object.
                objSqlCommand.Connection = _connection;

                // Executing sql query.
                intReturnValue = objSqlCommand.ExecuteNonQuery();

                CloseDBConnection();
                // Returning record id or rows affected as sql query executed successfully.
                return intReturnValue;
            }
            else
            {
                // Returning 0 as connection to database not established.
                return intReturnValue;
            }
        }

        /// <summary>
        /// Execute Scalar Sql Query
        /// </summary>
        /// <param name="objSqlCommand"></param>
        /// <returns></returns>
        public int ExecuteScalarSqlQuery(SqlCommand objSqlCommand)
        {
            int intReturnValue = 0;

            // Opening database connection.
            if (this.OpenDBConnection() == true)
            {
                // Assigning sql query to command object.
                objSqlCommand.Connection = this._connection;

                // Executing sql query.
                intReturnValue = Convert.ToInt32(objSqlCommand.ExecuteScalar());

                // Returning record id or rows affected as sql query executed successfully.
                return intReturnValue;
            }
            else
            {
                // Returning 0 as connection to database not established.
                return intReturnValue;
            }
        }

        /// <summary>
        /// Get DataSet Data object
        /// </summary>
        /// <param name="objCmd"></param>
        /// <returns></returns>
        public DataSet GetDataSet(SqlCommand objCmd)
        {
            // Creating object of DataAdapter class and assigning sql query and
            var objDA = new SqlDataAdapter(objCmd);
            // Opening database connection.
            if (this.OpenDBConnection() == true)
            {
                // Creating object of DataSet class.
                var objDS = new DataSet();

                // SqlDataReader objDR;
                // connection object to DataAdapter object.
                objCmd.Connection = this._connection;

                // Filling records in DataAdapter object.
                objDA.Fill(objDS);

                // returning DataTable.
                return objDS;
            }
            else
            {
                // Returning null as connection to database not established.
                return null;
            }
        }

        /// <summary>
        /// Get the Data Table object
        /// </summary>
        /// <param name="objCmd"></param>
        /// <returns></returns>
        public DataTable GetDataTable(SqlCommand objCmd)
        {
            // Creating object of DataAdapter class and assigning sql query and
            var objDA = new SqlDataAdapter(objCmd);
            // Opening database connection.
            if (this.OpenDBConnection() == true)
            {
                // Creating object of DataTable class.
                var objDt = new DataTable();

                // SqlDataReader objDR;
                // connection object to DataAdapter object.
                objCmd.Connection = this._connection;

                // Filling records in DataAdapter object.
                objDA.Fill(objDt);

                // returning DataTable.
                return objDt;
            }
            else
            {
                // Returning null as connection to database not established.
                return null;
            }
        }

        private bool OpenDBConnection()
        {
            bool isOpen = false;
            lock (this._connection)
            {
                // Opening connection to database.
                if (this._connection.State == ConnectionState.Closed)
                {
                    this._connection.Open();
                    isOpen = true;
                }
            }
            return isOpen;
        }

        private bool CloseDBConnection()
        {
            bool isClose = false;
            lock (this._connection)
            {
                // Closing connection to database.
                if (this._connection.State == ConnectionState.Open)
                {
                    this._connection.Close();
                    isClose = true;
                }
            }
            return isClose;
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of instance state.
        /// </summary>
        /// <param name="disposing">Determines whether this was called by Dispose or by the finalize.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // We can safely dispose of .NET resources.
                    this._connection.Close();
                }
                this.disposed = true;
            }
        }
    }
}