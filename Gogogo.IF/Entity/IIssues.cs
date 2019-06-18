using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IIssues
    {
        ulong id { get; set; }
        ulong product_id { get; set; }
        ulong creator_id { get; set; }
        ulong last_editor_id { get; set; }
        string from_who { get; set; }
        string title { get; set; }
        string remark { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }
}
