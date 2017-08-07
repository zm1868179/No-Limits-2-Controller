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
using System.Net;
using System.Net.Sockets;

namespace No_Limits_2_Controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TcpClient NL2Client;
        public MainWindow(TcpClient Client)
        {
            InitializeComponent();
            NL2Client = Client;
        }

        private void btn_SendIdle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
