using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IProductFeature
    {
        ulong id { get; set; }
        ulong product_id { get; set; }
        ulong module_id { get; set; }
        ulong creater_id { get; set; }
        ulong last_editor_id { get; set; }
        string tittle { get; set; }
        string remark { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }
}
