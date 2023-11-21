using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DbContext
{
    public class User
    {
        public int Id { get; set; }

        public string UserID { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }
    }
}
