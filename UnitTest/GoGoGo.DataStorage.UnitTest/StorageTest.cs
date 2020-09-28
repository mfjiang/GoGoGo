using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Linq;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using GoGoGo.Core;
using GoGoGo.Abstract;
using GoGoGo.Abstract.Entity;
using GoGoGo.Entity;

namespace GoGoGo.DataStorage.UnitTest
{
    [TestClass]
    public class StoreageTest
    {
        private string connstr = "server=localhost;database=GoGoGo;user=app_user;password=Today!IsAnNiceDay*666;charset=utf8;";

        [TestMethod]
        public void TestUserManager()
        {
            IUserManager manager = (IUserManager)new UserManager(connstr);
            Assert.IsNotNull(manager);

			//IUser user = new User();
			//user.created = DateTime.Now;
			//user.email = "admin@gmail.com";
			//user.employee_no = "1000";
			//user.work_groups = "admin";
			//user.is_banned = false;
			//user.mobile_no = "13600000000";
			//user.nick_name = "SystemAdmin";
			//user.pwd = "123456";
			//user.real_name = "James";
			//user.roles = "90";//System Admin
			//user.title = "Administrator";

			//ulong id = manager.AddUser(user);
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
