using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IProductVersion
    {
        ulong iteration_number { get; set; }
        ulong product_id { get; set; }
        string remark { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }
}
