using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.Windows;

namespace GetReportsFromBase
{
    internal class SqlConnect
    {
        private string _ServerName;
        private string _DbName;
        private string _UserId;
        private string _Password;
        private List<string> _BaseList;
        private SqlConnection _conn = new SqlConnection();

        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public string DbName { get { return _DbName; } set { _DbName = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public List<string> BaseList { get { return _BaseList; } set { _BaseList = value; } }

        public SqlConnect(string ServerName, string UserId, string Password, string DbName)
        {
            _ServerName = ServerName;
            _UserId = UserId;
            _Password = Password;
            _DbName = DbName;
        }
        public SqlConnect(string ServerName, string UserId, string Password)
        {
            _ServerName = ServerName;
            _UserId = UserId;
            _Password = Password;
            _DbName = "master";
        }
        public void Connect()
        {
            _conn = new SqlConnection();
            _conn.ConnectionString =
            "Data Source=" + _ServerName.ToString() + ";" +
            "Initial Catalog=" + _DbName.ToString() + ";" +
            "User id=" + _UserId.ToString() + ";" +
            "Password=" + _Password.ToString() + ";" +
            "Integrated Security=false;";
            try
            {
                GetBaseList();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                _BaseList = new List<string>();
            }
        }

        public void GetBaseList()
        {
            _conn.Open();
            SqlCommand sql_cmnd = new SqlCommand("SELECT [name] FROM master.dbo.sysdatabases WHERE dbid > 4", _conn);
            sql_cmnd.CommandType = CommandType.Text;
            sql_cmnd.ExecuteNonQuery();
            string sqlQuery = "SELECT [name] FROM master.dbo.sysdatabases WHERE dbid > 4";
            SqlDataAdapter adpt = new SqlDataAdapter(sqlQuery, _conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            _BaseList = new List<string>();
            foreach (DataRow dr in table.Rows)
            {
                _BaseList.Add(dr.ItemArray[0].ToString());
            }
            _conn.Close();
        }
    }
}
