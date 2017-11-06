using System;
using Capstone.DAL;
using Capstone.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.Runner();
        }
    }
}
