using System;
using System.Data.SqlClient;

namespace Medieval_Armies.Database
{
    internal class DataBase
    {
        private Singleton connection;
        private SqlConnection sqlConnection;

        public SqlConnection SqlConnection
        {
            get { return sqlConnection; }
            set { sqlConnection = value; }
        }
        public Singleton Connection
        {
            get { return connection; }
            set { connection = value; }
        }

        public DataBase(Singleton connection)
        {
            this.Connection = connection;
            this.SqlConnection = new SqlConnection(Connection.Connection);
        }

        public SqlCommand Request(string sqlText)
        {
            using (SqlCommand command = new SqlCommand(sqlText, this.SqlConnection))
                return command;
        }
    }
}