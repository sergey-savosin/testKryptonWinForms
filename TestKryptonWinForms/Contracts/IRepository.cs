using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKryptonWinForms.Contracts
{
    interface IRepository
    {
        List<string> GetAllConnectionNames();
        ConnectionDetails GetConnectionDetails(string connectionName);
        List<string> GetDatabaseNames(string connectionName);
        List<DatabaseObject> SearchObjects(string databaseName, string searchString);
        string GetObjectDefinition(DatabaseObject databaseObject);
    }
}
