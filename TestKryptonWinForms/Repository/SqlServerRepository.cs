using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestKryptonWinForms.Contracts;

namespace TestKryptonWinForms.Repository
{
    public class SqlServerRepository : IRepository
    {
        /// <summary>
        /// Список всех соединений к SqlServer
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllConnectionNames()
        {
            List<string> list = new List<string>()
            {
                "talent_manager","test"
            };
            return list;
        }

        /// <summary>
        /// Данные одного соединения SqlServer
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public ConnectionDetails GetConnectionDetails(string connectionName)
        {
            string databaseName = "";

            switch (connectionName)
            {
                case "talent_manager":
                    databaseName = "talent_manager";
                    break;
                case "test":
                    databaseName = "test";
                    break;
                default:
                    databaseName = "";
                    break;
            }

            return new ConnectionDetails()
            {
                ServerName = @"SergeyHome\SQLExpress",
                DefaultDatabaseName = databaseName,
                ConnectionName = connectionName
            };
        }

        /// <summary>
        /// Список баз данных указанного SqlServer
        /// </summary>
        /// <returns></returns>
        public List<string> GetDatabaseNames(string connectionName)
        {
            return new List<string>()
            {
                "talent_manager",
                "master",
                "test",
                "WideWorldImportersDW"
            };

        }

        public string GetObjectDefinition(DatabaseObject databaseObject)
        {
            throw new NotImplementedException();
        }

        public List<DatabaseObject> SearchObjects(string databaseName, string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
