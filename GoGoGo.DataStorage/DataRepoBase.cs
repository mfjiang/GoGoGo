using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using Dapper;
using Dapper.Contrib;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace GoGoGo.DataStorage
{
    /*
    Copyright (C)  2019 Jiang Ming Feng
    Github: https://github.com/mfjiang
    Contact: hamlet.jiang@live.com
    License:  https://github.com/mfjiang/GoGoGo/blob/master/LICENSE

    这一程序库是自由软件，您可以遵照自由软件基金会出版的 GNU General Public License （以下简称 GNU GPL v3）条款来修改和重新发布这一程序库，或者用许可证的第二版，或者 (根据您的选择) 用任何更新的版本。

    发布这一程序库的目的是希望它有用，但没有任何担保。甚至没有适合特定目的而隐含的担保。更详细的情况请参阅 GNU GPL v3条款。
    您应该已经和程序库一起收到一份 GNU GPL v3内容的副本。如果还没有，写信给：
    Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.

    This library is free software, you can modify and republish this program in accordance with the terms of the GNU Lesser General Public License published by the Free Software Foundation, or use the second version of the license, or (depending on your choice) Use any updated version.

    The purpose of publishing this library is to make it useful, but without any guarantee. There are no guarantees that are implied for a specific purpose. For more details, please refer to the GNU Lesser General Public License.

    You should have received a copy of the GNU Lesser General Public License along with the library. If not, write to:
    Free Software Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
    */

    public class DataRepoBase<TEntity> where TEntity : class
    {
        #region private fileds
        private string m_ConnStr = String.Empty;
        private IDbConnection m_MysqlConn = null;
        #endregion

        public IDbConnection Conn { get { return m_MysqlConn; } }

        public DataRepoBase(string connStr)
        {
            m_ConnStr = connStr;
            //just for test
            //m_MysqlConn = new MySqlConnection(connStr);
            //m_MysqlConn.Open();
            //m_MysqlConn.Close();
        }

        public virtual ulong Insert(TEntity entity)
        {
            ulong r = 0;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = (ulong)m_MysqlConn.Insert<TEntity>(entity);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual TEntity Get(object id)
        {
            TEntity r = null;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.Get<TEntity>(id);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Exists(object key, string tableName, string keyName)
        {
            long r = 0;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = String.Format("select count(*) as total from `{0}` where `{1}`=@{2}", tableName, keyName, key);
                MySqlParameter p1 = new MySqlParameter("@" + key, key);
                MySqlParameter[] parameters = new MySqlParameter[] { p1 };
                r = m_MysqlConn.ExecuteScalar<long>(sql, parameters);
                m_MysqlConn.Close();
            }
            return r > 0;
        }

        public virtual long Count(string tableName, string sqlWhere, params MySqlParameter[] parameters)
        {
            long r = 0;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = String.Format("select count(*) as total from `{0}` where {1}", tableName, sqlWhere);
                r = m_MysqlConn.ExecuteScalar<long>(sql, parameters);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual TEntity QuerySingle(CommandDefinition cmd)
        {
            TEntity r = null;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.QuerySingleOrDefault<TEntity>(cmd);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual IEnumerable<TEntity> Query(CommandDefinition cmd)
        {
            IEnumerable<TEntity> r = null;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.Query<TEntity>(cmd);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Update(TEntity entity)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.Update<TEntity>(entity);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(TEntity entity)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.Delete<TEntity>(entity);
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(string tableName, string keyName, ulong key)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = $"delete from {tableName} where `{keyName}` = {key}";
                r = m_MysqlConn.Execute(sql) > 0;
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(string tableName, string keyName, uint key)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = $"delete from {tableName} where `{keyName}` = {key}";
                r = m_MysqlConn.Execute(sql) > 0;
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(string tableName, string keyName, long key)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = $"delete from {tableName} where `{keyName}` = {key}";
                r = m_MysqlConn.Execute(sql) > 0;
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(string tableName, string keyName, Int32 key)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = $"delete from {tableName} where `{keyName}` = {key}";
                r = m_MysqlConn.Execute(sql) > 0;
                m_MysqlConn.Close();
            }
            return r;
        }

        public virtual bool Delete(string tableName, string keyName, string key)
        {
            bool r = false;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                string sql = $"delete from {tableName} where `{keyName}` = '{key}'";
                r = m_MysqlConn.Execute(sql) > 0;
                m_MysqlConn.Close();
            }
            return r;
        }
    }
}
