using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface ITestRecord
    {
        ulong id { get; set; }
        ulong iteration_id { get; set; }
        ulong product_id { get; set; }
        ulong module_id { get; set; }
        ulong use_case_id { get; set; }
        ulong creater_id { get; set; }
        string remark { get; set; }
        int report_type { get; set; }
        ulong report_to { get; set; }
        ulong executor_id { get; set; }
        string report_to_cc { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime? confirm_time { get; set; }
        DateTime? close_time { get; set; }
        DateTime created { get; set; }
    }
}
