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
using System.IO.Ports;
using System.Timers;

namespace ArduinoControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort p1;
        Timer t1;
        Timer t2;
        List<string> a;
        Reading red;
        public MainWindow()
        {
            InitializeComponent();
            p1 = new SerialPort("COM3");
            p1.Open();

            red = new Reading();
            a = new List<string>();

            t1 = new Timer();
            t1.Interval = 1000;
            t1.Elapsed += new ElapsedEventHandler(this.timerX);
            t1.Start();
            t2 = new Timer();
            t2.Interval = 5000;
            t2.Elapsed += new ElapsedEventHandler(this.timerX2);
            t2.Start();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void timerX(Object stateInfo, EventArgs e)
        {
            string read = p1.ReadExisting();
            if (read != " "&&read!="")
            {
                read = read.Split('\r')[0];
                //textBox.Text = read;
                //listBox.Items.Add(read);
                a.Add(read);
                listBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate () { listBox.Items.Add(read); }));
            }
        }
        private void timerX2(Object stateInfo, EventArgs e)
        {
            if (a.Count > 0)
            {
                string obj = a[0];
                a.RemoveAt(0);

                if (obj != null && obj != "")
                {
                    int code = red.returnType(obj);
                    listBox.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate () { listBox.Items.Add(red.returnMessage(code)); }));
                }
            }
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            
          
        }
    }
}
