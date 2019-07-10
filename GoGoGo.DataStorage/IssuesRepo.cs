using System;
using System.Text;
using System.Linq;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using Gogogo.Entity;

namespace GoGoGo.DataStorage
{
    public class IssuesRepo:DataRepoBase<Issues>
    {
        public IssuesRepo(string connStr):base(connStr)
        {

        }
    }
}
