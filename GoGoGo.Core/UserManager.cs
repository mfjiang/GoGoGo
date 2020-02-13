using Gogogo.IF;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using GoGoGo.DataStorage;
using Gogogo.Entity;
using Dapper;
using System.Data;
using Gogogo.IF.Entity;

namespace GoGoGo.Core
{
    /*
    Copyright (C)  2019 Jiang Ming Feng
    Github: https://github.com/mfjiang
    Contact: hamlet.jiang@live.com
    License:  https://github.com/mfjiang/GoGoGo/blob/master/LICENSE

    这一程序库是自由软件，您可以遵照自由软件基金会出版的 GNU General Public License （以下简称 GNU GPL v3）条款来修改和重新发布这一程序库，或者用许可证的第二版，或者 (根据您的选择) 用任何更新的版本。

    发布这一程序库的目的是希望它有用，但没有任何担保。甚至没有适合特定目的而隐含的担保。更详细的情况请参阅 GNU GPL v3条款。
    您应该已经和程序库一起收到一份 GNU GPL v3内容的副本。如果还没有，写信给：
    Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

    This library is free software, you can modify and republish this program in accordance with the terms of the GNU Lesser General Public License published by the Free Software Foundation, or use the second version of the license, or (depending on your choice) Use any updated version.

    The purpose of publishing this library is to make it useful, but without any guarantee. There are no guarantees that are implied for a specific purpose. For more details, please refer to the GNU Lesser General Public License.

    You should have received a copy of the GNU Lesser General Public License along with the library. If not, write to:
    Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
    */

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
        ulong IUserManager.AddUser(IUser user)
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

        bool IUserManager.DeleteUser(ulong id)
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

        DataSet IUserManager.GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields)
        {
            if (pageSize <= 0) { pageSize = 50; }
            if (pageNo <= 0) { pageNo = 1; }
            if (String.IsNullOrEmpty(fields)) { fields = "*"; }
            return m_UserRepo.GetDataPage(sqlQuery, orderBy, pageSize, pageNo, fields);
        }

        #region about user group
        IUserGroup IUserManager.AddGroup(string groupName, ulong cratorId, params ulong[] userIds)
        {
            UserGroup group = null;

            if (!String.IsNullOrEmpty(groupName))
            {
                group = new UserGroup();
                group.created = DateTime.Now;
                group.creator_id = cratorId;
                group.group_name = groupName;
                group.users = "";

                if (userIds.Length > 0)
                {
                    var ids = "";
					for (int i = 0; i < userIds.Length; i++)
					{
						ids += $"{userIds[i]},";
					}
                }
                m_UserGroupRepo.Insert(group);
            }

            return group;
		}

        bool IUserManager.RemoveGroup(string groupName)
        {
            bool done = false;
            if (!String.IsNullOrEmpty(groupName))
            {
                var temp = m_UserGroupRepo.Get(groupName);
                if (temp != null)
                {
                    done = m_UserGroupRepo.Delete(temp);
                }
            }
            return done;
		}

        void IUserManager.MoveInGroup(string groupName, ulong userId)
        {
            if (!String.IsNullOrEmpty(groupName))
            {
                var temp = m_UserGroupRepo.Get(groupName);
                if (temp != null)
                {
                    string[] ids = temp.users.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (ids.Length > 0 && !ids.Contains(userId.ToString()))
                    {
                        temp.users = $"{temp.users},{userId}";
                        m_UserGroupRepo.Update(temp);
                    }
                }
            }
        }

        void IUserManager.MoveOutGroup(string groupName, ulong userId)
        {
            if (!String.IsNullOrEmpty(groupName))
            {
                var temp = m_UserGroupRepo.Get(groupName);
                if (temp != null)
                {
                    string[] ids = temp.users.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    if (ids.Length > 0 && ids.Contains(userId.ToString()))
                    {
                        temp.users = "";
                        for (int i = 0; i < ids.Length; i++)
                        {
                            if (!ids[i].Equals(userId.ToString()))
                            {
                                temp.users += $"{ids[i]},";
                            }
						}
                        
                        m_UserGroupRepo.Update(temp);
                    }
                }
            }
        }

        IUserGroup IUserManager.GetGroup(string groupName)
        {
            UserGroup group = null;
            if (!String.IsNullOrEmpty(groupName))
            {
				group = m_UserGroupRepo.Get(groupName);
            }
            return group;
        }

        List<IUserGroup> IUserManager.FindGroups(string groupName)
        {
            DynamicParameters sp = new DynamicParameters();
            sp.Add("@group_name", groupName);
            var ugl = FindGroups("`group_name` like concat('%',@group_name,'%')", sp);
            return ugl;

        }
        #endregion

        #endregion

        private List<IUserGroup> FindGroups(string sqlQueryNoWhere, object paramas)
        {
            string querybase = $"select * from usergroup where {sqlQueryNoWhere.Replace("where", " ")} order by `group_name` asc limit 999";
            List<IUserGroup> ls = new List<IUserGroup>();
            CommandDefinition cmdd = new CommandDefinition(querybase, paramas, null, null, System.Data.CommandType.Text, CommandFlags.Buffered);

            var ul = m_UserGroupRepo.Query(cmdd);
            for (int i = 0; i < ul.Count(); i++)
            {
                ls.Add((IUserGroup)ul.ElementAt(i));
            }
            return ls;
        }

        private List<IUser> Find(string sqlQueryNoWhere, object paramas)
        {
            string querybase = $"select * from user where {sqlQueryNoWhere.Replace("where", " ")} order by `id` desc limit 100";
            List<IUser> ls = new List<IUser>();
            CommandDefinition cmdd = new CommandDefinition(querybase, paramas, null, null, System.Data.CommandType.Text, CommandFlags.Buffered);

            var ul = m_UserRepo.Query(cmdd);
            for (int i = 0; i < ul.Count(); i++)
            {
                ls.Add((IUser)ul.ElementAt(i));
            }
            return ls;
        }
    }
}
