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
//    [TestClass]
//    public class ReservationDALTests
//    {
//        private TransactionScope tran;
//        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=campground;Integrated Security=True";
//        private int parkID;
//        private int cgID;
//        private int siteID;
//        private int resID;


//        [TestInitialize]
//        public void Initialize()
//        {
//            tran = new TransactionScope();

//            using (SqlConnection conn = new SqlConnection(connectionString))
//            {
//                SqlCommand cmd;
//                conn.Open();

//<<<<<<< HEAD
//                cmd = new SqlCommand("INSERT INTO park VALUES ('Glacier National Park', 'Montana', '1910-05-11', 2548, 2946681, 'Glacier National Park is a 1,583 sq.mi. wilderness area in Montanas Rocky Mountains, with glacier carved peaks and valleys running to the Canadian border. Its crossed by the mountainous Going To The Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake. Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.');", conn);
//                cmd.ExecuteNonQuery();

//                cmd = new SqlCommand("SELECT park_ID from park where name = 'Glacier National Park';", conn);
//                parkID = (int)cmd.ExecuteScalar();

//                cmd = new SqlCommand(@"INSERT INTO campground VALUES (@parkID, 'Fish Creek', 04, 11, 23.00);", conn);
//                cmd.Parameters.AddWithValue("parkID", parkID);
//                cmd.ExecuteNonQuery();

//                cmd = new SqlCommand("SELECT campground_id from campground where name = 'Fish Creek';", conn);
//                campgroundID = (int)cmd.ExecuteScalar();

//                cmd = new SqlCommand(@"INSERT INTO site VALUES (@campgroundID, 1, 8, 0, 0, 0);", conn);
//                cmd.Parameters.AddWithValue("campgroundID", campgroundID);
//                cmd.ExecuteNonQuery();

//                cmd = new SqlCommand(@"SELECT reservation_id from reservation where reservation_id = @reservationID;", conn);
//                cmd.Parameters.AddWithValue("reservationID", reservationID);
//                testID = (int)cmd.ExecuteNonQuery();
//=======
//                cmd = new SqlCommand("INSERT INTO park VALUES ('Glacier National Park', 'Montana', '1910-05-11', 2548, 2946681, 'Glacier National Park is a 1,583 sq.mi. wilderness area in Montanas Rocky Mountains, with glacier carved peaks and valleys running to the Canadian border. Its crossed by the mountainous Going To The Sun Road. Among more than 700 miles of hiking trails, it has a route to photogenic Hidden Lake. Other activities include backpacking, cycling and camping. Diverse wildlife ranges from mountain goats to grizzly bears.'); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
//                parkID = (int)cmd.ExecuteScalar();

//                cmd = new SqlCommand(@"INSERT INTO campground VALUES (@parkID, 'Fish Creek', 04, 11, 23.00); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
//                cmd.Parameters.AddWithValue("@parkID", parkID);
//                cgID = (int)cmd.ExecuteScalar();

//                cmd = new SqlCommand(@"INSERT INTO site VALUES (@cgID, 1, 8, 0, 0, 0); SELECT CAST(SCOPE_IDENTITY() as int);", conn);
//                cmd.Parameters.AddWithValue("@cgID", cgID);
//                siteID = (int)cmd.ExecuteScalar();

//                cmd = new SqlCommand(@"INSERT INTO reservation VALUES (@siteID, 'Alex', '12-17-1991', '12-17-1992', GETDATE()); SELECT CAST(SCOPE_IDENTITY() as int)", conn);
//                cmd.Parameters.AddWithValue("@siteID", siteID);
//                resID = (int)cmd.ExecuteScalar();
//>>>>>>> 05080f5fd6eee3996958837add14eaf553136a56
//            }
//        }

//        [TestCleanup]
//        public void Cleanup()
//        {
//            tran.Dispose();
//        }

//        //Test MakeReservation() taking in int siteNumSelection, string reservationName, & DateTime arrive/departDates

//        [TestMethod()]
//        public void MakeReservationTest()
//        {
//            ReservationDAL reservationDAL = new ReservationDAL(connectionString);

//            DateTime arriveDate = Convert.ToDateTime("06/05/2016");
//            DateTime departDate = Convert.ToDateTime("06/15/2016");

//            int reservationID = reservationDAL.MakeReservation(siteID, "Test Name", arriveDate, departDate);

//            Assert.AreEqual(resID + 1, reservationID);
//        }
//    }
}
