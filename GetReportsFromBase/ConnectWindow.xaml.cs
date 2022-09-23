using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace GetReportsFromBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnect _sqlConnect;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((cmbx.Items.Count == 0) || cmbx.SelectedValue is null) 
            { 
                Connect(); 
            }
            else 
            { 
                Connect(cmbx.SelectedValue.ToString()); 
            }
        }
        private void Connect()
        {
            _sqlConnect = new SqlConnect(txt_ip.Text, txt_id.Text, txt_pwd.Password);
            _sqlConnect.Connect();
            List<string> list = new List<string>(_sqlConnect.BaseList);
            cmbx.Items.Clear();
            foreach (string s in list)
            {
                cmbx.Items.Add(s);
            }
        }
        private void Connect(string DbName)
        {
            _sqlConnect = new SqlConnect(txt_ip.Text, txt_id.Text, txt_pwd.Password, DbName);
            _sqlConnect.Connect();
        }
    }
}
