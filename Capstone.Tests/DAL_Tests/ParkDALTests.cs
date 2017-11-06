using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Data.SqlClient;
using Capstone.Models;
using Capstone.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Capstone.Tests.DAL_Tests
{
    [TestClass]
    public class ParkDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=campground;Integrated Security=True";
        private int existingParks = 0;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("SELECT COUNT(*) FROM park;", conn);
                existingParks = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO park VALUES ('Glacier National Park', 'Montana', '1910-05-11', 2548, 2946681, 'Glacier National Park is a 1,583 sq.mi. wilderness area in Montanas Rocky Mountains, with glacier carved peaks and valleys running to the Canadian border. Its crossed by the mountainous Going To The Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake. Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.')", conn);
                cmd.ExecuteNonQuery();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod()]
        public void GetParksTest()
        {
            ParkDAL parkDAL = new ParkDAL(connectionString);

            List<Park> parks = parkDAL.GetParks();

            Assert.AreEqual(existingParks + 1, parks.Count);
            Assert.AreEqual("Glacier National Park", parks[parks.Count - 1].Name);
        }
    }
}
