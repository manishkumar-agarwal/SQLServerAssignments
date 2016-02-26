using DBWrapper;
using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace DBWrapperTests
{
    /// <summary>
    /// Summary description for DBInteractionTests
    /// </summary>
    [TestClass]
    public class DBInteractionTests
    {
        public DBInteractionTests()
        {
            dbInteractionInstance = new DBInteraction();
        }

        private DBInteraction dbInteractionInstance;

        [TestMethod]
        public void CheckDBConnectionBeforeEstablishingConnectionTest()
        {
            Assert.AreEqual(false, DBInteraction.CheckDBConnection());
        }

        [TestMethod]
        public void CheckDBConnectionAfterEstablishingConnectionTest()
        {
            Assert.AreEqual(false, DBInteraction.CheckDBConnection());
            var connectedToDBFlag = DBInteraction.SetUpDBConnection();
            Assert.AreEqual(true, connectedToDBFlag);
        }

        [TestMethod]
        public void CheckDBConnectionEstablishingReconnectionTest()
        {
            Assert.AreEqual(false, DBInteraction.CheckDBConnection());
            var connectedToDBFlag = DBInteraction.SetUpDBConnection();
            Assert.AreEqual(true, connectedToDBFlag);
            var reconnectedToDBFlag = DBInteraction.SetUpDBConnection();
            Assert.AreEqual(false, reconnectedToDBFlag);
        }

        [TestMethod]
        public void GenerateSQLCommandWithNoSqlParamtersTest()
        {
            var spName = "HelloWorld";
            var spParameterList = new List<SqlParameter>();
            var expectedSqlCommandText = "EXEC HelloWorld";
            var sqlCommand = DBInteraction.GenerateSQLCommand(spName, spParameterList);
            Assert.AreEqual(spParameterList.Count, sqlCommand.Parameters.Count);
            Assert.AreEqual(expectedSqlCommandText, sqlCommand.CommandText);

        }

        [TestMethod]
        public void GenerateSQLCommandWithOneSqlParamtersTest()
        {
            var spName = "HelloWorld";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@spVar1", 123));
            var expectedSqlCommandText = "EXEC HelloWorld @spVar1";
            var sqlCommand = DBInteraction.GenerateSQLCommand(spName, spParameterList);
            Assert.AreEqual(spParameterList.Count, sqlCommand.Parameters.Count);
            Assert.AreEqual(expectedSqlCommandText, sqlCommand.CommandText);

        }

        [TestMethod]
        public void GenerateSQLCommandWithListOfSqlParamtersTest()
        {
            var spName = "HelloWorld";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@spVar1", 123));
            spParameterList.Add(new SqlParameter("@spVar2", "Hello"));
            spParameterList.Add(new SqlParameter("@spVar3", false));
            var expectedSqlCommandText = "EXEC HelloWorld @spVar1, @spVar2, @spVar3";
            var sqlCommand = DBInteraction.GenerateSQLCommand(spName, spParameterList);
            Assert.AreEqual(spParameterList.Count, sqlCommand.Parameters.Count);
            Assert.AreEqual(expectedSqlCommandText, sqlCommand.CommandText);

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void ExecuteSelectWithInvalidSPTest()
        {
            var spName = "HelloWorld";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@spVar1", 123));
            spParameterList.Add(new SqlParameter("@spVar2", "Hello"));
            spParameterList.Add(new SqlParameter("@spVar3", false));
            var queryResult = DBInteraction.ExecuteSelect(spName, spParameterList);

        }

        [TestMethod]
        public void ExecuteSelectWithValidSPAndNoParametersTest()
        {
            var spName = "[TelephoneSystem].[uspGetAllCustomers]";
            var spParameterList = new List<SqlParameter>();
            var queryResult = DBInteraction.ExecuteSelect(spName, spParameterList);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void ExecuteSelectWithValidSPAndInvalidParameterValueTest()
        {
            var spName = "[TelephoneSystem].[uspGetCustomerById]";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@customerMobileNumer", "abc"));
            var queryResult = DBInteraction.ExecuteSelect(spName, spParameterList);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod]
        public void ExecuteSelectWithValidSPAndValidParameterValueTest()
        {
            var spName = "[TelephoneSystem].[uspGetCustomerById]";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@customerMobileNumer", 01));
            var queryResult = DBInteraction.ExecuteSelect(spName, spParameterList);
            Assert.IsInstanceOfType(queryResult, typeof(SqlDataReader));
            queryResult.Close();
        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void ExecuteNonSelectWithInvalidSPTest()
        {
            var spName = "HelloWorld";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@spVar1", 123));
            spParameterList.Add(new SqlParameter("@spVar2", "Hello"));
            spParameterList.Add(new SqlParameter("@spVar3", false));
            var queryResult = DBInteraction.ExecuteNonSelect(spName, spParameterList);

        }

        [TestMethod]
        [ExpectedException(typeof(SqlException))]
        public void ExecuteNonSelectWithValidSPAndInvalidParameterValueTest()
        {
            var spName = "[TelephoneSystem].[uspUpdateCustomer]";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@customerMobileNumer", "abc"));
            spParameterList.Add(new SqlParameter("@CustomerEmailAddress", "abc@mymail.com"));

            var updateCount = DBInteraction.ExecuteNonSelect(spName, spParameterList);
            Assert.IsInstanceOfType(updateCount, typeof(int));
        }

        [TestMethod]
        public void ExecuteNonSelectWithValidSPAndValidParameterValueTest()
        {
            var spName = "[TelephoneSystem].[uspUpdateCustomer]";
            var spParameterList = new List<SqlParameter>();
            spParameterList.Add(new SqlParameter("@customerMobileNumer", 01));
            spParameterList.Add(new SqlParameter("@CustomerEmailAddress", "abc@mymail.com"));

            var updateCount = DBInteraction.ExecuteNonSelect(spName, spParameterList);
            Assert.IsInstanceOfType(updateCount, typeof(int));
            Assert.AreEqual(0, updateCount);
        }
    }
}
