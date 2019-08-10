using Gogogo.IF;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using GoGoGo.DataStorage;
using Gogogo.Entity;
using Dapper;

namespace GoGoGo.Core
{
    public class UserManager : IUserManager
    {
        #region private fields
        private UserRepo m_UserRepo;
        private UserGroupRepo m_UserGroupRepo;
        private string m_ConnStr;
        #endregion

        public UserManager(string connstr)
        {
            if (String.IsNullOrEmpty(connstr))
            {
                throw new ArgumentNullException("connstr");
            }

            m_ConnStr = connstr;
            m_UserRepo = new UserRepo(connstr);
            m_UserGroupRepo = new UserGroupRepo(connstr);
        }

        #region interface implementation
        ulong IUserManager.Add(IUser user)
        {
            ulong uid = 0;
            uid = m_UserRepo.Insert((User)user);
            return uid;
        }

        bool IUserManager.Update(IUser user)
        {
            bool done = false;
            done = m_UserRepo.Update((User)user);
            return done;
        }

        bool IUserManager.Delete(ulong id)
        {
            bool done = false;
            done = m_UserRepo.Delete("user", "id", id);
            return done;
        }
        IUser IUserManager.Get(ulong id)
        {
            return (IUser)m_UserRepo.Get(id);
        }

        List<IUser> IUserManager.FindByNickName(string name)
        {
            DynamicParameters sp = new DynamicParameters();            
            sp.Add("@nick_name", name);
            var ul = Find("`nick_name` like concat('%',@nick_name,'%')", sp);
            return ul;
        }
        List<IUser> IUserManager.FindByRealName(string name)
        {
            DynamicParameters sp = new DynamicParameters();
            sp.Add("@real_name", name);
            var ul = Find("`real_name` like concat('%',@real_name,'%')", sp);
            return ul;
        }
        List<IUser> IUserManager.FindByMoblie(string mobile)
        {
            DynamicParameters sp = new DynamicParameters();
            sp.Add("@mobile_no", mobile);
            var ul = Find("`mobile_no` like concat('%',@mobile_no,'%')", sp);
            return ul;
        }
        List<IUser> IUserManager.FindByEmail(string email)
        {
            DynamicParameters sp = new DynamicParameters();
            sp.Add("@email", email);
            var ul = Find("`email` like concat('%',@email,'%')", sp);
            return ul;
        }
        #endregion

        private List<IUser> Find(string sqlQueryNoWhere, object paramas)
        {
            string querybase = $"select * from user where {sqlQueryNoWhere.Replace("where", "")} order by `id` desc limit 100";
            List<IUser> ls = new List<IUser>();
            CommandDefinition cmdd = new CommandDefinition(querybase, paramas, null, null, System.Data.CommandType.Text, CommandFlags.Buffered);

            var ul = m_UserRepo.Query(cmdd);
            for (int i = 0; i < ul.Count(); i++)
            {
                ls.Add((IUser)ul.Take(i + 1).FirstOrDefault());
            }
            return ls;
        }
    }
}
