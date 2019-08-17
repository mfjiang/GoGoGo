using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gogogo.IF
{
    public interface IUserManager
    {
        ulong Add(IUser user);
        bool Update(IUser user);
        bool Delete(ulong id);
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
        
    }
}
