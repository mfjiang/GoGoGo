using System;
using System.Collections.Generic;
using System.Text;

namespace Gogogo.IF
{
    public interface IUser
    {
        ulong id { get; set; }
        string wx_uuid { get; set; }
        string wx_name { get; set; }
        string nick_name { get; set; }
        string real_name { get; set; }
        string pwd { get; set; }
        string group { get; set; }
        string employee_no { get; set; }
        string mobile_no { get; set; }
        string email { get; set; }
        string last_login_ip { get; set; }
        bool is_banned { get; set; }
        DateTime? last_login_date { get; set; }
        string last_session_id { get; set; }
        DateTime created { get; set; }
    }
}
