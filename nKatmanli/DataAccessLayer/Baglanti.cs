using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class Baglanti
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-6ERATV1U\\SQLEXPRESS;Initial Catalog=PersonelBilgi;Integrated Security=True");


    }
}
