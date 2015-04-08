using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zdzhantai
{
    /// <summary>
    /// trace.xaml 的交互逻辑
    /// </summary>
    public partial class trace : Window
    {
        SerialPort sp ;
        String result;
        public trace()
        {
            InitializeComponent();
            get_scr();
        }
        private void get_scr()
        {
            sp = new SerialPort();

           // sp.PortName = "COM1";
            sp.PortName = Conf.getCOM();
            sp.BaudRate = 115200;
            sp.DataReceived += readSer;
            try
            {
                sp.Open();

            }
            catch (Exception e){
                MessageBox.Show("串口打开失败！请检查设置！");
            }
        }
        void readSer(Object sender, SerialDataReceivedEventArgs e)
        {
            result = sp.ReadExisting();
            MessageBox.Show(result);
            this.Dispatcher.Invoke(new EventHandler(changelable));
        }

        private void changelable(Object sender,EventArgs e)
        {
            this.label1.Content = result;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            sp.Close();
            this.Close();
        }
    }
}
