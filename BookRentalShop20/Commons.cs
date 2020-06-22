using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalShop20
{
    public static class Commons
    {
        public static string CONNSTRING = "Data Source=127.0.0.1;Initial Catalog=BookRentalShopDB;Persist Security Info=True;User ID=sa;Password=p@ssw0rd!";

        public static string LOGINUSERID { get; internal set; }
    }
}
