﻿using System;
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
            return DBInterface.GetAllCustomers();
        }

        internal static SqlDataReader DisplayCustomerByID()
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader DisplayCustomerBillHistory()
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader DisplayAllEmployees()
        {
            return DBInterface.GetAllEmployees();
        }

        internal static SqlDataReader DisplayEmployeeByID()
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader DisplayEmployeesCustomers()
        {
            throw new NotImplementedException();
        }

        internal static SqlDataReader DisplayBonusForEmployee()
        {
            throw new NotImplementedException();
        }
    }
}