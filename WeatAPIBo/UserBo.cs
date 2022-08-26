using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatAPIBo
{
    public class UserBo
    {
        public static WeatAPImodels.WeatAPIEntities.WContext db = new WeatAPImodels.WeatAPIEntities.WContext();
        public static WeatAPImodels.User.AddUserR AddUser(WeatAPImodels.User.AddUserP model)
        {

            var r = new WeatAPImodels.User.AddUserR();
            WeatAPImodels.WeatAPIEntities.User userSearch = (from u in db.User where u.Phone == model.phone select u).FirstOrDefault();
            if (userSearch == null)
            {
                WeatAPImodels.WeatAPIEntities.User user = new WeatAPImodels.WeatAPIEntities.User();
                user.Phone = model.phone;
                user.Password = model.password;
                user.NickName = model.nickName;
                user.State = model.state;
                db.User.Add(user);
                int i = db.SaveChanges();
                if (i > 0)
                {
                    r.code = 1;
                    r.message = "数据插入成功";
                }
                else
                {
                    r.code = 0;
                    r.message = "数据插入成功";
                }
            }
            else
            {
                r.code = 0;
                r.message = "手机号已经存在";
            }
            return r;
        }
    }
}
