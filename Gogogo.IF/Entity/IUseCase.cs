using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IUseCase
    {
        ulong id { get; set; }
        ulong product_id { get; set; }
        ulong module_id { get; set; }
        ulong creater_id { get; set; }
        ulong last_editor_id { get; set; }
        string test_path { get; set; }
        string remark { get; set; }
        string paramas { get; set; }
        string expected_results { get; set; }
        string tested_results { get; set; }
        bool quality_pass { get; set; }
        DateTime created { get; set; }
    }
}
