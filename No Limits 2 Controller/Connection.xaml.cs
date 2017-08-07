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
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace No_Limits_2_Controller
{
    /// <summary>
    /// Interaction logic for Connection.xaml
    /// </summary>
    public partial class Connection : Window
    {
        public Connection()
        {
            InitializeComponent();
        }

        //Try to connect to the specifed IP Address
        private void btn_Connect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create the tcp client and attempt to connect to it.
                TcpClient client = new TcpClient();
                client.Connect(IPAddress.Parse(tb_IPAddress.Text), 15151);
                if (client.Connected)
                {
                    MainWindow MainDisplay = new MainWindow(client);
                    MainDisplay.Show();
                    this.Close();
                }
            }
            catch (ArgumentNullException er)
            {
                ErrorDisplay newError = new ErrorDisplay(er.ToString());
                newError.DataContext = this;
                newError.ShowDialog();
                //Console.WriteLine("ArgumentNullException: {0}", er);
            }
            catch (SocketException er)
            {
                ErrorDisplay newError = new ErrorDisplay(er.ToString());
                newError.DataContext = this;
                newError.ShowDialog();
                //Console.WriteLine("SocketException: {0}", er);
            }
            catch (FormatException er)
            {
                ErrorDisplay newError = new ErrorDisplay("You have Entered an Invalid IP Address.");
                newError.DataContext = this;
                newError.ShowDialog();
                //Console.WriteLine("SocketException: {0}", er);
            }





        }
    }
}
