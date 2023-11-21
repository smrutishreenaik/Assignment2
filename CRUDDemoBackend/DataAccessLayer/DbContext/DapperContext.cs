using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext()
        {           
            _connectionString = "Data Source=.;Initial Catalog=Training;Integrated Security=True";
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
