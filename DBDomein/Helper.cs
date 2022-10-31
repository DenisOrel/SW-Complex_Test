using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDomein
{
    internal class Helper
    {
        private SqlConnection myConnection = new SqlConnection();
        private SqlConnection cn = new SqlConnection();

        private string dbName;
        private string sqlserverName;
        private string User;
        private string Pass;

        public string DBName
        {
            get { return dbName; }
            set { dbName = value; }
        }

        public string SqlServerName
        {
            get { return sqlserverName; }
            set { sqlserverName = value; }
        }

        public string SQLUser
        {
            get { return User; }
            set { User = value; }
        }

        public string SQLPassword
        {
            get { return Pass; }
            set { Pass = value; }
        }

        public void Open()
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder();

            myBuilder.UserID = User;

            myBuilder.Password = Pass;

            myBuilder.InitialCatalog = dbName;

            myBuilder.DataSource = sqlserverName;

            myBuilder.ConnectTimeout = 30;

            myConnection.ConnectionString = myBuilder.ConnectionString;

            cn.ConnectionString = myBuilder.ConnectionString;
            cn.Open();
        }

        public void Close()
        {
            cn.Close();
        }
    }
}