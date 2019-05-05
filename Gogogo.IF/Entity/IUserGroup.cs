using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF.Entity
{
    public interface IUserGroup
    {
        string group_name { get; set; }
        string users { get; set; }//id1,id2,id3,...
        ulong creator_id { get; set; }
        DateTime created { get; set; }
    }
}
