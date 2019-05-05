using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF.Entity
{
    public interface IMessage
    {
        ulong id { get; set; }
        ulong sender_id { get; set; }
        ulong send_to_id { get; set; }
        string send_to_group { get; set; }
        ulong product_id { get; set; }
        ulong module_id { get; set; }
        ulong feature_id { get; set; }
        ulong task_id { get; set; }
        ulong test_record_id { get; set; }
        string content { get; set; }
        DateTime created { get; set; }

    }
}
