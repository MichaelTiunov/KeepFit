using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using KeepFit.Core.Domain.Entity;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace KeepFit.Core.DataAccess
{
    public abstract class DataAccessBase
    {
        private static readonly Dictionary<string, Lazy<Database>> Databases = new Dictionary<string, Lazy<Database>>();

        protected const string KeepFitBase = "KeepFitBase";

        static DataAccessBase()
        {
            Databases.Add(KeepFitBase, new Lazy<Database>(() => DatabaseFactory.CreateDatabase(KeepFitBase)));
        }

        protected IDataReader ExecuteReader(string databaseName, string storedProcName, Action<Database, DbCommand> fillParamsDelegate = null)
        {
            var database = Databases[databaseName].Value;

            using (var cmd = database.GetStoredProcCommand(storedProcName))
            {
                if (fillParamsDelegate != null)
                {
                    fillParamsDelegate(database, cmd);
                }

                return database.ExecuteReader(cmd);
            }
        }

        protected IDataReader ExecuteReader(string databaseName, string storedProcName, Action<Database, DbCommand> fillParamsDelegate, out Func<string, Object> getOutValues)
        {
            var database = Databases[databaseName].Value;

            using (var cmd = database.GetStoredProcCommand(storedProcName))
            {
                if (fillParamsDelegate != null)
                    fillParamsDelegate(database, cmd);

                var reader = database.ExecuteReader(cmd);

                getOutValues = outputParamName => database.GetParameterValue(cmd, outputParamName);

                return reader;
            }
        }

        protected object ExecuteScalar(string databaseName, string storedProcName, Action<Database, DbCommand> fillParamsDelegate)
        {
            var database = Databases[databaseName].Value;

            using (var cmd = database.GetStoredProcCommand(storedProcName))
            {
                if (fillParamsDelegate != null)
                    fillParamsDelegate(database, cmd);

                var obj = database.ExecuteScalar(cmd);

                return obj;
            }
        }

        protected int ExecuteNonQuery(string databaseName, string storedProcName, Action<Database, DbCommand> fillParamsDelegate = null, Action<Database, DbCommand> getOutParams = null)
        {
            var database = Databases[databaseName].Value;

            using (var cmd = database.GetStoredProcCommand(storedProcName))
            {
                if (fillParamsDelegate != null)
                {
                    fillParamsDelegate(database, cmd);
                }

                int retVal = database.ExecuteNonQuery(cmd);

                if (getOutParams != null)
                {
                    getOutParams(database, cmd);
                }

                return retVal;
            }
        }

        protected void AddAuditableEntityParameters(Database database, DbCommand command, AuditableEntity auditableEntity)
        {
            database.AddInParameter(command, "CreatedByID", DbType.Int32, auditableEntity.CreatedById);
            database.AddInParameter(command, "CreatedDate", DbType.DateTime, auditableEntity.CreatedDate);
            database.AddInParameter(command, "LastUpdatedByID", DbType.Int32, auditableEntity.LastUpdatedById);
            database.AddInParameter(command, "LastUpdatedDate", DbType.DateTime, auditableEntity.LastUpdatedDate);
        }
    }
}
