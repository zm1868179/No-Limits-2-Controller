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

namespace No_Limits_2_Controller
{
    /// <summary>
    /// Interaction logic for ErrorDisplay.xaml
    /// </summary>
    public partial class ErrorDisplay : Window
    {

        public ErrorDisplay(string errormessage)
        {
            InitializeComponent();
            //Display the Error Message
            tbl_ErrorMessage.Text = errormessage;
        }

        //Close the Window
        private void btn_Okerror_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
