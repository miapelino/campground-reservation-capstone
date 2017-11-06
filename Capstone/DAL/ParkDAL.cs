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
    public class ParkDAL
    {
        private const string getParks = "SELECT * FROM park ORDER BY name;";
        private string connectionString;

        public ParkDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(getParks, connection);
                    SqlDataReader results = cmd.ExecuteReader();

                    int counter = 1;

                    while (results.Read())
                    {
                        Park park = new Park(Convert.ToInt32(results["park_id"]), counter, Convert.ToString(results["name"]), Convert.ToString(results["location"]), Convert.ToDateTime(results["establish_date"]), Convert.ToInt32(results["area"]), Convert.ToInt32(results["visitors"]), Convert.ToString(results["description"]));
                        parks.Add(park);

                        counter++;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw;
            }
            return parks;
        }
    }
}
