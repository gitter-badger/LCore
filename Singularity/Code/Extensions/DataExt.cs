using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Singularity.Extensions
    {
    public static class DataExt
        {
        public static DataTable GetSchema(this SqlConnection In)
            {
            DataTable t = In.GetSchema("Tables");
            return t;
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

