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
        private UserRepo m_UserRepo;
        private UserGroupRepo m_UserGroupRepo;
        private string m_ConnStr;

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
        long IUserManager.Add(IUser user)
        {
            long uid = 0;
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

        List<IUser> IUserManager.Find(string sqlQueryNoWhere, params object[] paramas)
        {
            string querybase = $"select * from user where {sqlQueryNoWhere.Replace("where", "")}";
            List<IUser> ls = new List<IUser>();
            CommandDefinition cmdd = new CommandDefinition(sqlQueryNoWhere, paramas);
            var ul = m_UserRepo.Query(cmdd);
            for (int i = 0; i < ul.Count(); i++)
            {
                ls.Add((IUser)ul.Take(i + 1));
            }
            return ls;
        }
        #endregion
    }
}
