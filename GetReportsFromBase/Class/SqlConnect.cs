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
using System.Printing;
using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace GetReportsFromBase.Class
{
    public class DBName
    {
        private int _Id;
        private string _DBName;
        public int Id { get { return _Id; } set { _Id = value; } }
        public string DB_Name { get { return _DBName; } set { _DBName = value; } }
    }
    public class SqlConnect
    {
        private string _ServerName;
        private DBName _DbName;
        private string _UserId;
        private string _Password;
        private Collection<DBName> _BaseList = new Collection<DBName>();
        private SqlConnection _conn = new SqlConnection();
        private Boolean _IsConectedToBase;

        public string ServerName { get { return _ServerName; } set { _ServerName = value; } }
        public DBName DbName { get { return _DbName; } set { _DbName = value; } }
        public string UserId { get { return _UserId; } set { _UserId = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public Collection<DBName> BaseList { get { return _BaseList; } set { _BaseList = value; } }
        public Boolean IsConectedToBase { get { return _IsConectedToBase; } set { _IsConectedToBase = value; } }

        public SqlConnect()
        {
            _ServerName = "";
            _UserId = "";
            _Password = "";
            _DbName = new DBName() { Id = 0, DB_Name = "master" };
            _IsConectedToBase = false;
            _BaseList.Add(_DbName);
        }
        public void Connect()
        {
            _conn.ConnectionString =
            "Data Source=" + _ServerName.ToString() + ";" +
            "Initial Catalog=" + _DbName.DB_Name.ToString() + ";" +
            "User id=" + _UserId.ToString() + ";" +
            "Password=" + _Password.ToString() + ";" +
            "Integrated Security=false;";
            try
            {
                GetBaseList();
                IsConected();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void GetBaseList()
        {
            _conn.Open();
            string sqlQuery = "SELECT [dbid], [name] FROM master.dbo.sysdatabases WHERE dbid > 4";
            SqlDataAdapter adpt = new SqlDataAdapter(sqlQuery, _conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            _BaseList.Clear();
            _BaseList.Add(_DbName);
            foreach (DataRow row in table.Rows)
            {
                _BaseList.Add(new DBName() { Id = Int32.Parse(row[0].ToString()), DB_Name = row[1].ToString() });
            }
            _conn.Close();
        }
        private void IsConected()
        {
            _IsConectedToBase = false;
            if (_DbName.DB_Name != "master")
            {
                _IsConectedToBase = true;
            }
        }
        public DataTable GetTable(string sqlQuery)
        {
            SqlDataAdapter adpt = new SqlDataAdapter(sqlQuery, _conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            _conn.Close();
            return table;
        }
    }
}
