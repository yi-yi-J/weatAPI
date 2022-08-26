using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatAPImodels.WeatAPIEntities
{
    public partial class User
    {
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string MsgCode { get; set; }
        public DateTime? RegTime { get; set; }//此处的问号表示RegTime允许为空
        public string NickName { get; set; }
        public int? State { get; set; }
    }
}
