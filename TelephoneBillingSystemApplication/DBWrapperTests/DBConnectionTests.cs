using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBWrapper.Tests
{
    [TestClass()]
    public class DBConnectionTests
    {
        [TestMethod()]
        public void FirstConnectToDBTest()
        {
            DBConnection dbConnection = new DBConnection();

            var connectionSuccessFlag = dbConnection.ConnectToDB();
            Assert.AreEqual(true, connectionSuccessFlag);
            Assert.AreEqual(true, dbConnection.IsConnectedToDB);

        }

        [TestMethod()]
        public void SecondConnectToDBTest()
        {
            DBConnection dbConnection = new DBConnection();

            var connectionSuccessFlag = dbConnection.ConnectToDB();
            connectionSuccessFlag = dbConnection.ConnectToDB();
            Assert.AreEqual(false, connectionSuccessFlag);
            Assert.AreEqual(true, dbConnection.IsConnectedToDB);

        }

        [TestMethod()]
        public void DisposeConnectionToDBTest()
        {
            DBConnection dbConnection = new DBConnection();

            var connectionSuccessFlag = dbConnection.ConnectToDB();
            Assert.AreEqual(true, connectionSuccessFlag);
            Assert.AreEqual(true, dbConnection.IsConnectedToDB);

            var disconnectFromDBFlag = dbConnection.DisposeSQLConnection();

            Assert.AreEqual(true, disconnectFromDBFlag);
            Assert.AreEqual(false, dbConnection.IsConnectedToDB);
            

        }

        [TestMethod()]
        public void CheckConnectionStringWithDefaultConstructor()
        {
            DBConnection dbConnection = new DBConnection();
            var expectedConnectionString = "Data Source=(local);Initial Catalog=AssignmentDatabase;Integrated Security=true";
            Assert.AreEqual(expectedConnectionString, dbConnection.ConnectionString);

        }

        [TestMethod()]
        public void CheckConnectionStringWithOverloadedConstructor()
        {
            DBConnection dbConnection = new DBConnection("abc");
            var expectedConnectionString = "abc";
            Assert.AreEqual(expectedConnectionString, dbConnection.ConnectionString);

        }

        [TestMethod()]
        public void ConnectToDifferentDBTest()
        {
            DBConnection dbConnection = new DBConnection();

            var connectionSuccessFlag = dbConnection.ConnectToDB();
            var newConnectionString = "Data Source=(local);Initial Catalog=AdventureWorks;Integrated Security=true";

            Assert.AreEqual(true, connectionSuccessFlag);
            Assert.AreEqual(true, dbConnection.IsConnectedToDB);
            Assert.AreNotEqual(newConnectionString, dbConnection.ConnectionString);

            var newDBConnectionFlag = dbConnection.ConnectToDifferentDB(newConnectionString);
            Assert.AreEqual(true, newDBConnectionFlag);
            Assert.AreEqual(true, dbConnection.IsConnectedToDB);
            Assert.AreEqual(newConnectionString, dbConnection.ConnectionString);

        }
    }
}