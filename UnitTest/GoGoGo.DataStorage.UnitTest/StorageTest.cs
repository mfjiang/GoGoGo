using Gogogo.Entity;
using Gogogo.IF;
using GoGoGo.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace GoGoGo.DataStorage.UnitTest
{
    [TestClass]
    public class StoreageTest
    {
        private string connstr = "server=127.0.0.1;database=gogogo;user=app_user;password=Today!IsAnNiceDay*666;charset=utf8;";

        [TestMethod]
        public void TestUserManager()
        {
            IUserManager manager = new UserManager(connstr);
            Assert.IsNotNull(manager);

            //IUser user = new User();
            //user.created = DateTime.Now;
            //user.email = "test@gmail.com";
            //user.employee_no = "1000";
            //user.group = "admin";
            //user.is_banned = false;
            //user.mobile_no = "13600000000";
            //user.nick_name = "SystemAdmin";
            //user.pwd = "123456";
            //user.real_name = "James";
            //user.roles = "90";//System Admin
            //user.title = "System Administrator";

            //ulong id = manager.Add(user);
            //Assert.IsTrue(id > 0);

            IUser temp = manager.Get(1);
            Assert.IsNotNull(temp);

            var ul = manager.FindByRealName(temp.real_name);
            Assert.IsTrue(ul.Count > 0);

            var ul2 = manager.FindByNickName(temp.nick_name);
            Assert.IsTrue(ul2.Count > 0);

            var ul3 = manager.FindByEmail(temp.email);
            Assert.IsTrue(ul3.Count > 0);

            var ul4 = manager.FindByMoblie(temp.mobile_no);
            Assert.IsTrue(ul4.Count > 0);
        }
    }
}
