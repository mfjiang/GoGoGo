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
            //m_MysqlConn = new MySqlConnection(connStr);
        }

        public virtual long Insert(TEntity entity)
        {
            long r = 0;
            using (m_MysqlConn = new MySqlConnection(m_ConnStr))
            {
                m_MysqlConn.Open();
                r = m_MysqlConn.Insert<TEntity>(entity);
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
            }
            return r;
        }
    }
}
