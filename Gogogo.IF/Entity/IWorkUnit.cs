using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IWorkUnit
    {
        int parent_id { get; set; }
        int id { get; set; }
        int product_id { get; set; }
        ulong ver_iter_number { get; set; }
        int module_id { get; set; }
        ulong creater_id { get; set; }
        string tittle { get; set; }

        DateTime? plan_to_start_at { get; set; }
        DateTime? plan_to_finish_at { get; set; }
    }
}
