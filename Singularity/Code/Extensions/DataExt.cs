using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using LCore.Interfaces;

namespace Singularity.Extensions
    {
    [ExtensionProvider]
    public static class DataExt
        {
        public static DataTable GetSchema(this SqlConnection In)
            {
            var Tables = In.GetSchema("Tables");
            return Tables;
            /*
            SQLSchema Out = new SQLSchema();


            return Out;
            */
            }

        public class SQLSchema
            {
            public List<SQLSchemaTable> Tables { get; set; }
            }

        public class SQLSchemaTable
            {
            public List<SQLSchemaTableField> Fields { get; set; }
            }

        public class SQLSchemaTableField
            {
            public string FieldName { get; set; }

            }
        }
    }

