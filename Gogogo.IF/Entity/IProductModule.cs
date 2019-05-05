using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IProductModule
    {
        ulong id { get; set; }
        ulong iteration_number { get; set; }
        ulong parent_id { get; set; }
        ulong product_id { get; set; }
        string tittle { get; set; }
        string remark { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }
}
