using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IProduct
    {
        ulong id { get; set; }
        string code { get; set; }
        string name { get; set; }
        string remark { get; set; }
        string main_ver { get; set; }
        string source_uri { get; set; }
        string open_api_uri { get; set; }
        ulong creater_id { get; set; }
        int level { get; set; }
        int state { get; set; }
        DateTime created { get; set; }
    }

}
