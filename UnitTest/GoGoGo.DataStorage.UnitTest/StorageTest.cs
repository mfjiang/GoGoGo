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

            DynamicParameters sp = new DynamicParameters();
            //sp.Add("@real_name", "Jam", System.Data.DbType.String, System.Data.ParameterDirection.Input,40);
            sp.Add("@real_name", "Jam");
            var ul = manager.Find("`real_name` like concat('%',@real_name,'%')", sp);
            Assert.IsTrue(ul.Count > 0);
        }
    }
}
