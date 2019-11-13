using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    class userConfiguration
    {
        private static string user = "";
        private static string userpass = "";
        private static string userposition = "";

        public static string User
        {
            get { return  user; }
            set { user = value; }
        }

        public static string UserPassword
        {
            get { return userpass; }
            set { userpass = value; }
        }

        public static string Position
        {
            get { return userposition; }
            set { userposition = value; }
        }
    }
}
