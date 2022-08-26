using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatAPImodels.User
{
    public class AddUserP
    {
        public string phone { get; set; }
        public string password { get; set; }
        public string nickName { get; set; }
        public int state { get; set; }
        public string sign { get; set; }
    }
}
