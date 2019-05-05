using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IAgileProject
    {
        ulong creater_id { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime? plan_to_start_at { get; set; }
        DateTime? plan_to_finish_at { get; set; }
        List<IWorkUnit> work_units { get; set; }
        List<ILandmark> landmarks { get; set; }
        DateTime created { get; set; }

    }

    

   
}
