using Azure;
using GetReportsFromBase.Class;
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
            _sqlConnect = new SqlConnect();
            DataContext = _sqlConnect;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _sqlConnect.Connect();
            btn_rep.IsEnabled = _sqlConnect.IsConectedToBase;
        }

        private void btn_rep_Click(object sender, RoutedEventArgs e)
        {
            Reports Reports = new Reports(_sqlConnect);
            //Reports.setConnect(_sqlConnect);
            Reports.Show();
        }

        private void txt_pwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _sqlConnect.Password = txt_pwd.Password;
        }
    }
}
