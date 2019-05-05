using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IProductRequirement
    {
        ulong id { get; set; }
        ulong creater_id { get; set; }
        ulong last_editor_id { get; set; }
        string from_who { get; set; }
        string tittle { get; set; }
        string remark { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }
}
