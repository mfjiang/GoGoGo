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
        List<IUser> Find(string sqlQueryNoWhere, object paramas);
    }
}
