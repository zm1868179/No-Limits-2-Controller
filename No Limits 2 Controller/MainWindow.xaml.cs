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
using System.Runtime.InteropServices;

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
        
        struct Nl2TelemetryMessage
        {
            public byte magicStart; //magic start (uchar8)
            public ushort typeId; //this is the ushort16
            public uint requestId; //this is the uint32
            public ushort dataSize; //this is the second ushort
            public byte magicEnd; //magic end (uchar8)
        }

        //Convert Struts to Byte Arrays
        private byte[] StructureToByteArray(object obj)
        {
            int len = Marshal.SizeOf(obj);

            byte[] arr = new byte[len];

            IntPtr ptr = Marshal.AllocHGlobal(len);

            Marshal.StructureToPtr(obj, ptr, true);

            Marshal.Copy(ptr, arr, 0, len);

            Marshal.FreeHGlobal(ptr);

            return arr;
        }

        //Return the Data Recieved back in to a Strut
        void ByteArrayToStructure(byte[] bytearray, ref object obj)
        {
            int len = Marshal.SizeOf(obj);

            IntPtr i = Marshal.AllocHGlobal(len);

            Marshal.Copy(bytearray, 0, i, len);

            obj = Marshal.PtrToStructure(i, obj.GetType());

            Marshal.FreeHGlobal(i);
        }

        private byte[] CreateMessage(ushort Typeid, uint Requestid, ushort datasize)
        {

            Nl2TelemetryMessage message = new Nl2TelemetryMessage();
            var utf8 = Encoding.UTF8;
            string magicstart = "N";
            string magicend = "L";
            byte[] startbytesarray = utf8.GetBytes(magicstart);
            byte[] endbytesarray = utf8.GetBytes(magicend);
            byte startbytes = startbytesarray[0];
            byte endbytes = endbytesarray[0];

            message.magicStart = startbytes;
            message.typeId = Typeid;
	        message.requestId = Requestid;
	        message.dataSize = datasize;
            message.magicEnd = endbytes;


	        Byte[] ConvertedStruct = StructureToByteArray(message);

            return ConvertedStruct;

        }

    private void btn_SendIdle_Click(object sender, RoutedEventArgs e)
        {
            //Get the Stream to send and recieve data
            Byte[] data = CreateMessage(0, 1, 0);
            NetworkStream stream = NL2Client.GetStream();
            
            stream.Write(data, 0, data.Length);
            //make a buffer to store the response
            data = new Byte[20];
            string responsedata = string.Empty;
            //Cant read for some reason 
            //Int32 bytes = stream.Read(data, 0, data.Length);

            stream.Close();

        }
    }
}
