using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IUserManager
    {
        ulong Add(IUser user);
        bool Update(IUser user);
        bool Delete(ulong id);
        IUser Get(ulong id);
        List<IUser> FindByNickName(string name);
        List<IUser> FindByRealName(string name);
        List<IUser> FindByMoblie(string mobile);
        List<IUser> FindByEmail(string email);
    }
}
