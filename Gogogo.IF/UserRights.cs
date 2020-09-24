using System;
using System.Collections.Generic;
using System.Text;

namespace GoGoGo.Abstract
{
    public enum UserRights : int
    {
        SystemEdit = 100,//CRUD
        SystemBrowse  =101,//LIST,READ        

        ProjectEdit = 200,//CRUD
        ProjectBrowse = 201,//LIST,READ
        ProjectApproval = 202,//DENY,ACCESS

        WorkUnitEdit = 300,//CRUD
        WorkUnitBrowse = 301,//LIST,READ
        WorkUnitApproval =302,//DENY,ACCESS

        ProductEdit = 400,//CRUD
        ProductBrowse = 401,//LIST,READ
        ProdcutApproval = 402,//DENY,ACCESS

        TaskEdit = 500,//CRUD
        TaskBrowse = 501,//LIST,READ
        TaskApproval = 502,//DENY,ACCESS

        IssuesEdit = 600,//CRUD
        IssuesBrowse = 601,//LIST,READ
        IssuesApproval = 602,//DENY,ACCESS

        TestEdit = 700,//CRUD
        TestBrowse = 701,//LIST,READ
        TestApproval = 702,//DENY,ACCESS

        UserEdit = 800,//CRUD
        UserBrowse = 801,//LIST,READ
        UserApproval = 802,//DENY,ACCESS

        SupperRights = 10000 //ROOT
    }
}
