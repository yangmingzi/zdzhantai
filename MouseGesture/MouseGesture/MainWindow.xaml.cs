using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Threading;


namespace MouseGesture
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += new MouseButtonEventHandler(mousedown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(mounseup);
            //this.MouseMove += new MouseEventHandler(mousemove);
            
        }

        public Point orign;

        private void mousedown(object sender, MouseEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{
            //    MessageBox.Show("点击");
            //    System.Windows.Point position = e.GetPosition(this);
            //    double x1 = position.X;
            //    while (e.LeftButton == MouseButtonState.Released)
            //    {
            //        System.Windows.Point position2 = e.GetPosition(this);
            //        double x2 = position2.X;
            //        if (x2 - x1 > 0) { MessageBox.Show("左滑"); }
            //        if (x2 - x1 < 0) { MessageBox.Show("右滑"); }
            //    }
            //}
            //else
            //{
            //    System.Windows.Point position = e.GetPosition(this);
            //    double x1 = position.X;
            //    MessageBox.Show(x1.ToString());
            //}



        }

        private void mousemove(object sender, MouseEventArgs e)
        {
            //if (e.LeftButton == MouseButtonState.Pressed)
            //{

            //    System.Windows.Point position = e.GetPosition(this);
            //    double x1 = position.X;

            //    while (e.LeftButton == MouseButtonState.Released)
            //    {
            //        System.Windows.Point position2 = e.GetPosition(this);
            //        double x2 = position2.X;
            //        if (x2 - x1 > 0) { MessageBox.Show("左滑"); }
            //        if (x2 - x1 < 0) { MessageBox.Show("右滑"); }
            //    }
            //}
        }
        private void mousedown(object sender, MouseButtonEventArgs e)
        {
            orign = e.GetPosition(this);
        }

        private void mounseup(object sender, MouseButtonEventArgs e)
        {
            Point endpot = e.GetPosition(this);
            if (endpot.X - orign.X > 0)
            {
                MessageBox.Show("left");
            }
            else {
                MessageBox.Show("right");
            }
        }
    }
}
