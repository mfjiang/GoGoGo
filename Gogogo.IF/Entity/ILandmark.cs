using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface ILandmark
    {
        DateTime deadline { get; set; }
        string tittle { get; set; }
        string remark { get; set; }
        int state { get; set; }
        DateTime? finished { get; set; }
    }
}
