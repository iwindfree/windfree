using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using windfree.common.windfree.configure;

namespace windfree.common.dbio
{
    class ConnectionManager
    {
        static ConnectionManager instance = null;
        static object syncObj = new object();
        SqlConnectionStringBuilder connStringBuilder;
        Configure conf = null;
        SqlConnection conn;

        public static ConnectionManager GetInstance()
        {
            if (instance == null)
            {
                lock (syncObj)
                {
                    if (instance == null)
                    {
                        instance = new ConnectionManager();
                    }
                }
            }
            return instance;
        }

        private ConnectionManager()
        {
            connStringBuilder = new SqlConnectionStringBuilder();
            //conf = Configure.getInstance();
            init();
        }

        public SqlConnection GetConnection()
        {
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connStringBuilder.ConnectionString;
                conn.Open();
                return conn;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        private void init()
        {
            connStringBuilder.DataSource = conf.getConfigValue("server");
            connStringBuilder.UserID = conf.getConfigValue("userid");
            connStringBuilder.Password = conf.getConfigValue("password");
            connStringBuilder.InitialCatalog = conf.getConfigValue("database");
            connStringBuilder.MinPoolSize = 2;
            connStringBuilder.MultipleActiveResultSets = true;
        }



        private SqlConnection getPhysicalConnection()
        {

            try
            {
                conn = new SqlConnection();
                ///todo: connect to database

                conn.ConnectionString = connStringBuilder.ConnectionString;

                conn.Open();
            }
            catch (Exception ex)
            {

            }
            return conn;
        }
    }
}
