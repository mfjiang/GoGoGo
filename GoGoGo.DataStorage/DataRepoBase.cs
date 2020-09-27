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

        /// <summary>
        /// get data page
        /// </summary>
        /// <param name="sqlQuery">sql command，without 'where'</param>
        /// <param name="orderBy">order command，without 'order by'</param>
        /// <param name="fields">fields，'*' as default</param>
        /// <param name="pageSize">page size</param>
        /// <param name="pageNo">page number</param>        
        /// <returns></returns>
        public virtual DataSet GetDataPage(string sqlQuery, string orderBy, string tableName, int pageSize = 10, int pageNo = 1, string fields = "*")
        {
            //IN p_table_name        VARCHAR(1024),        /*表名*/
            //IN p_fields            VARCHAR(1024),        /*查询字段*/
            //IN p_page_size         INT,                  /*每页记录数*/
            //IN p_page_now          INT,                  /*当前页*/
            //IN p_order_string      VARCHAR(128),         /*排序条件(包含ORDER关键字,可为空)*/
            //IN p_where_string      VARCHAR(1024),        /*WHERE条件(包含WHERE关键字,可为空)*/
            //OUT p_out_rows          INT

            var p1 = new MySqlParameter("@p_table_name", tableName)
            {
                Direction = ParameterDirection.Input
            };

            var p2 = new MySqlParameter("@p_fields", string.IsNullOrWhiteSpace(fields) ? "*" : fields)
            {
                Direction = ParameterDirection.Input
            };

            var p3 = new MySqlParameter("@p_page_size", pageSize)
            {
                Direction = ParameterDirection.Input
            };

            var p4 = new MySqlParameter("@p_page_now", pageNo)
            {
                Direction = ParameterDirection.Input
            };

            var p5 = new MySqlParameter("@p_order_string", string.IsNullOrWhiteSpace(orderBy) ? "" : " order by " + orderBy)
            {
                Direction = ParameterDirection.Input
            };

            var p6 = new MySqlParameter("@p_where_string", string.IsNullOrWhiteSpace(sqlQuery) ? "" : " where " + sqlQuery)
            {
                Direction = ParameterDirection.Input
            };

            MySqlParameter[] parameters = new MySqlParameter[]
            {
                p1,p2,p3,p4,p5,p6
            };
            DataSet ds = null;

            if (parameters.Length > 0)
            {
                string sql =
                    $"call get_data_pager({"@p_table_name"},{"@p_fields"},{"@p_page_size"},{"@p_page_now"},{"@p_order_string"},{"@p_where_string"})";
                using (MySqlConnection conn =new MySqlConnection(m_ConnStr))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    }
                    ds = MySqlHelper.ExecuteDataset(conn, sql, parameters);
                    conn.Close();
                }
            }
            return ds;
        }

        /// <summary>
        /// convert data table to a dictionary list
        /// </summary>
        /// <param name="dt">data table</param>
        /// <returns></returns>
        public virtual List<Dictionary<string, object>> TableToList(DataTable dt)
        {
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDictionary(dr));
                }
            }

            return list;
        }

        /// <summary>
        /// convert data row to a dictionary
        /// </summary>
        /// <param name="row">data row</param>
        /// <returns></returns>
        public virtual Dictionary<string, object> RowToDictionary(DataRow row)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            DataTable temp = row.Table;
            for (int i = 0; i < temp.Columns.Count; i++)
            {
                dic.Add(temp.Columns[i].ColumnName, row[i]);
            }

            return dic;
        }

        /// <summary>
        /// convert a dictionary to an entity
        /// </summary>
        /// <typeparam name="T">entity class</typeparam>
        /// <param name="dic">data dictionary</param>
        /// <returns></returns>
        public virtual T DicToObject<T>(Dictionary<string, object> dic) where T : new()
        {
            var md = new T();
            foreach (var d in dic)
            {
                var filed = d.Key;
                var value = d.Value;
                var pinfo = md.GetType().GetProperty(filed);
                if (pinfo != null && value != null && !value.GetType().Equals(typeof(DBNull)))
                {
                    if (pinfo.PropertyType.Equals(typeof(Boolean)))
                    {
                        if (int.Parse(d.Value.ToString()) == 0)
                        {
                            value = false;
                        }
                        else
                        {
                            value = true;
                        }
                    }

                    if (pinfo.PropertyType.Equals(typeof(DateTime?)))
                    {
                        DateTime dateTime;
                        if (DateTime.TryParse(d.Value.ToString(), out dateTime))
                        {
                            value = dateTime;
                        }
                        else
                        {
                            value = null;
                        }
                    }

                    pinfo.SetValue(md, value);

                }
            }
            return md;
        }

        /// <summary>
        /// convert a data row to  an entity
        /// </summary>
        /// <typeparam name="T">entity class</typeparam>
        /// <param name="row">data row</param>
        /// <returns></returns>
        public virtual T RowToEntity<T>(DataRow row) where T : new()
        {
            T entity = default(T);
            if (row != null)
            {
                try
                {
                    Dictionary<string, object> dic = RowToDictionary(row);
                    entity = DicToObject<T>(dic);
                }
                catch (Exception ex)
                {
                    throw new Exception("convert to dictionary format failed", ex);
                }
            }
            return entity;
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
