using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBWrapper;

namespace UserInterfaceFunctions
{
    class UserInterfaceToDbAccessFunctions
    {
        internal static SqlDataReader DisplayAllCustomers()
        {
            SqlDataReader queryResult = DBInterface.GetAllCustomers();
            return queryResult;
        }
    }
}
