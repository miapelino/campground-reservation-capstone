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

namespace Capstone.Tests
{
    [TestClass]
    public class CampgroundDALTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=campground;Integrated Security=True";
        private int parkID = 0;

        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd;
                conn.Open();

                cmd = new SqlCommand("INSERT INTO park VALUES ('Glacier National Park', 'Montana', '1910-05-11', 2548, 2946681, 'Glacier National Park is a 1,583 sq.mi. wilderness area in Montanas Rocky Mountains, with glacier carved peaks and valleys running to the Canadian border. Its crossed by the mountainous Going To The Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake. Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.')", conn);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("SELECT park_ID from park where name = 'Glacier National Park'", conn);
                parkID = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand("INSERT INTO campground VALUES (4, 'Fish Creek', 04, 11, 23.00)", conn);
                cmd.ExecuteNonQuery();


            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        //Test GetCampground() method by Park ID

        [TestMethod()]
        public void GetCampgroundsTest()
        {
            CampgroundDAL campgroundDAL = new CampgroundDAL(connectionString);

            List<Campground> campgrounds = campgroundDAL.GetCampgrounds(parkID);

            Assert.AreEqual(1, campgrounds.Count);
            Assert.AreEqual("Fish Creek", campgrounds[0].Name);
        }
    }
}
