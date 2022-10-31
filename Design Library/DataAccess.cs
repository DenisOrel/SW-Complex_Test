using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Design_Library
{
    public class DataAccess
    {
        public List<OBJTYPES_TREE> ObjectsTree()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SWComplex")))
            {
            }
            // List<OBJTYPES_TREE> t = new List<OBJTYPES_TREE>();

            return null;
        }
    }
}