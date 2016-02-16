using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterfaceFunctions
{
    class UserInterfaceDisplayFunctions
    {
        internal static void DisplayQueryResult(SqlDataReader queryResult)
        {
            if (!queryResult.HasRows)
            {
                Console.WriteLine("No data found. Please retry with a different Criteria");
                return;
            }

            DisplayQueryResultHeader(queryResult);

            while (queryResult.Read())
            {
                for (int i = 0; i < queryResult.FieldCount; i++)
                {
                    Console.Write("\t{0}\t", queryResult[i]);
                }
                Console.WriteLine();

            }
            queryResult.Close();
        }

        private static void DisplayQueryResultHeader(SqlDataReader queryResult)
        {
            for (int i = 0; i < queryResult.FieldCount; i++)
            {
                Console.Write("{0}\t", queryResult.GetName(i));
            }
            Console.WriteLine();
        }
    }
}
