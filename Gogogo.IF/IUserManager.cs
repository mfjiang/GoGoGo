using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using GoGoGo.Abstract.Entity;

namespace GoGoGo.Abstract
{
    public interface IUserManager
    {
        #region about user

        ulong AddUser(IUser user);
        bool Update(IUser user);
        bool DeleteUser(ulong id);
        IUser Get(ulong id);
		
		/// <summary>
		/// limits in 100
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		List<IUser> FindByNickName(string name);
        /// <summary>
        /// limits in 100
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        List<IUser> FindByRealName(string name);
        /// <summary>
        ///  limits in 100
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        List<IUser> FindByMoblie(string mobile);
        /// <summary>
        ///  limits in 100
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        List<IUser> FindByEmail(string email);

        DataSet GetDataPage(string sqlQuery, string orderBy, int pageSize, int pageNo, string fields);
        #endregion

        #region about user group
        IUserGroup AddGroup(string groupName, ulong cratorId, params ulong[] userIds);
        bool RemoveGroup(string groupName);
        void MoveInGroup(string groupName, ulong userId);
        void MoveOutGroup(string groupName, ulong userId);
        IUserGroup GetGroup(string groupName);
        List<IUserGroup> FindGroups(string groupName);
		#endregion
	}
}
