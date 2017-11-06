using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.DAL;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests.DAL_Tests
{
    [TestClass]
    public class SiteDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=campground;Integrated Security=True";
        private DateTime arriveDate;
        private DateTime departDate;
        private int parkID;
        private int cgID;
        private int siteID;
        private int siteID2;
        private int resID;
        private int resID2;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("INSERT INTO park VALUES ('Glacier National Park', 'Montana', '1910-05-11', 2548, 2946681, 'Glacier National Park is a 1,583 sq.mi. wilderness area in Montanas Rocky Mountains, with glacier carved peaks and valleys running to the Canadian border. Its crossed by the mountainous Going To The Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake. Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.'); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                parkID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(@"INSERT INTO campground VALUES (@parkID, 'Fish Creek', 04, 11, 23.00); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                cmd.Parameters.AddWithValue("@parkID", parkID);
                cgID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(@"INSERT INTO site VALUES (@cgID, 1, 8, 0, 0, 0); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                cmd.Parameters.AddWithValue("@cgID", cgID);
                siteID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(@"INSERT INTO site VALUES (@cgID, 1, 8, 0, 0, 0); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
                cmd.Parameters.AddWithValue("@cgID", cgID);
                siteID2 = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(@"INSERT INTO reservation VALUES (@siteID, 'Alex', '12-17-2017', '12-18-2017', GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int)", conn);
                cmd.Parameters.AddWithValue("@siteID", siteID);
                resID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(@"INSERT INTO reservation VALUES (@siteID2, 'Rob', '12-19-2017', '12-20-2017', GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int)", conn);
                cmd.Parameters.AddWithValue("@siteID2", siteID2);
                resID2 = (int)cmd.ExecuteScalar();

            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        //test GetAvailableSites taking in int cgID, DateTime arriveDate, DateTime departDate

        [TestMethod()]
        public void GetAvailableSitesTest()
        {
            SiteDAL siteDAL = new SiteDAL(connectionString);

            arriveDate = Convert.ToDateTime("12/17/2017");
            departDate = Convert.ToDateTime("12/18/2017");

            List<Site> sites = siteDAL.GetAvailableSites(cgID, arriveDate, departDate);

            Assert.AreEqual(1, sites.Count);

            //arriveDate = Convert.ToDateTime("12-16-2017");
            //departDate = Convert.ToDateTime("12-19-2017");

            //List<Site> siteTest2 = siteDAL.GetAvailableSites(cgID, arriveDate, departDate);

            //Assert.AreEqual(0, siteTest2.Count);

        }
    }
}
