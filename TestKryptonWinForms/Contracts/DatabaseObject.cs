using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKryptonWinForms.Contracts
{
    public class DatabaseObject
    {
        public string ObjectName;
        public string SchemaName;
        public string DisplayName => SchemaName + "." + ObjectName;
        public string DatabaseName;
        public string ObjectType;
    }
}
