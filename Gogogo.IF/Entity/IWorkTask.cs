using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IWorkTask
    {
        ulong id { get; set; }
        ulong creater_id { get; set; }
        ulong owner_id { get; set; }
        int task_type { get; set; }
        string tittle { get; set; }
        int level { get; set; }
        int state { get; set; }
        ulong product_id { get; set; }
        ulong module_id { get; set; }
        ulong test_record_id { get; set; }
       
        DateTime? confirm_time { get; set; }
        DateTime? close_time { get; set; }
        DateTime created { get; set; }
    }
}
