using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DBWrapper.Tests
{
    [TestClass()]
    public class DBInterfaceTests
    {
        [TestMethod()]
        public void GetAllCustomersTest()
        {
            var queryResult = DBInterface.GetAllCustomers();
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetCustomerByIDTest()
        {
            var customerMobileNumber = 0;
            var queryResult = DBInterface.GetCustomerByID(customerMobileNumber);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetCustomerBillHistoryTest()
        {
            var customerMobileNumber = 0;
            var queryResult = DBInterface.GetCustomerBillHistory(customerMobileNumber);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetCutomersForEmployeeTest()
        {
            var employeeId = 0;
            var queryResult = DBInterface.GetCutomersForEmployee(employeeId);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetSummaryForEmployeesTest()
        {
            var queryResult = DBInterface.GetSummaryForEmployees();
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetBonusForEmployeeTest()
        {
            var employeeId = 0;
            var queryResult = DBInterface.GetBonusForEmployee(employeeId);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetEmployeeByIdTest()
        {
            var employeeId = 0;
            var queryResult = DBInterface.GetEmployeeById(employeeId);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void GetAllEmployeesTest()
        {
            var queryResult = DBInterface.GetAllEmployees();
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod()]
        public void UpdateCustomerTestWithInvalidCustomer()
        {
            var customerMobileNumer = 0;
            var newCustomerEmailAddress = "sample@mymail.com";
            var noOfCustomerUpdates = DBInterface.UpdateCustomer(customerMobileNumer, newCustomerEmailAddress);
            Assert.AreEqual(0, noOfCustomerUpdates);
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void UpdateCustomerTestWithInvalidCustomerUpdate()
        {
            var customerMobileNumer = 0;
            string newCustomerEmailAddress = null;
            var noOfCustomerUpdates = DBInterface.UpdateCustomer(customerMobileNumer, newCustomerEmailAddress);
            Assert.AreEqual(0, noOfCustomerUpdates);
        }

        [TestMethod()]
        public void UpdateCustomerTestWithValidCustomerUpdate()
        {
            var customerMobileNumer = 1234567890;
            string newCustomerEmailAddress = "mymail@mymail.com";
            var noOfCustomerUpdates = DBInterface.UpdateCustomer(customerMobileNumer, newCustomerEmailAddress);
            Assert.AreEqual(1, noOfCustomerUpdates);
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void RecordBillPaymentForInvalidCustomerTest()
        {
            var customerMobileNumber = 0;
            var billPaymentMode = "Debit Card";
            decimal billAmount = 100;
            var noOfInserts = DBInterface.RecordBillPaymentForCustomer(customerMobileNumber,
                billPaymentMode, billAmount);
            Assert.AreEqual(1, noOfInserts);
        }


        [TestMethod()]
        public void RecordBillPaymentForValidCustomerTest()
        {
            var customerMobileNumber = 1234567890;
            var billPaymentMode = "Debit Card";
            decimal billAmount = 100;
            var noOfInserts = DBInterface.RecordBillPaymentForCustomer(customerMobileNumber,
                billPaymentMode, billAmount);
            Assert.AreEqual(1, noOfInserts);
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void AddCutomerWithPrimaryKeyIssueTest()
        {
            var customerMobileNumber = 1234567890;
            var customerName = "Shyama";
            var customerEmail = "Shyama@mymail.com";
            var employeeId = 0;
            var customerIdentity = "Passport";
            var noOfInserts = DBInterface.AddCutomer(customerMobileNumber, customerName, customerEmail,
                employeeId, customerIdentity);
            Assert.AreEqual(1, noOfInserts);
        }

        [TestMethod()]
        [ExpectedException(typeof(SqlException))]
        public void AddCutomerWithForeignKeyIssueTest()
        {
            var customerMobileNumber = 1234567895;
            var customerName = "Shyama";
            var customerEmail = "Shyama@mymail.com";
            var employeeId = 0;
            var customerIdentity = "Passport";
            var noOfInserts = DBInterface.AddCutomer(customerMobileNumber, customerName, customerEmail,
                employeeId, customerIdentity);
            Assert.AreEqual(1, noOfInserts);
        }

        [TestMethod()]
        public void AddCutomerTest()
        {
            var customerMobileNumber = 1234567895;
            var customerName = "Shyama";
            var customerEmail = "Shyama@mymail.com";
            var employeeId = 1;
            var customerIdentity = "Passport";
            var noOfInserts = DBInterface.AddCutomer(customerMobileNumber, customerName, customerEmail,
                employeeId, customerIdentity);
            Assert.AreEqual(1, noOfInserts);
        }
    }
}