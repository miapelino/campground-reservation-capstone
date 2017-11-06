using System;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Models;

namespace Capstone.DAL
{
    public class CampgroundDAL
    {
        private const string getCampgrounds = @"SELECT * FROM campground WHERE park_id = @parkID ORDER BY name;";
        private string connectionString;

        public CampgroundDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Campground> GetCampgrounds(int parkID)
        {
            List<Campground> campgrounds = new List<Campground>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(getCampgrounds, connection);
                    cmd.Parameters.AddWithValue("parkID", parkID);
                    SqlDataReader results = cmd.ExecuteReader();

                    int counter = 1;

                    while (results.Read())
                    {
                        Campground campground = new Campground(Convert.ToInt32(results["campground_id"]), counter, Convert.ToInt32(results["park_id"]), Convert.ToString(results["name"]), Convert.ToInt32(results["open_from_mm"]), Convert.ToInt32(results["open_to_mm"]), Convert.ToDecimal(results["daily_fee"]));
                        campgrounds.Add(campground);

                        counter++;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
            }
            return campgrounds;
        }
    }
}
