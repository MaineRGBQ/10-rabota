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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp51
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Switch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RotateSwitch(sender as Rectangle);
        }

        private void Switch_MouseEnter(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.Width += 10;
            rect.Height += 20;
            Canvas.SetLeft(rect, Canvas.GetLeft(rect) - 5);
            Canvas.SetTop(rect, Canvas.GetTop(rect) - 10);
        }

        private void Switch_MouseLeave(object sender, MouseEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            rect.Width -= 10;
            rect.Height -= 20;
            Canvas.SetLeft(rect, Canvas.GetLeft(rect) + 5);
            Canvas.SetTop(rect, Canvas.GetTop(rect) + 10);
        }

        private void RotateSwitch(Rectangle rect)
        {
            if (rect != null)
            {
                RotateTransform rotateTransform = new RotateTransform();
                rect.RenderTransform = rotateTransform;

                DoubleAnimation da = new DoubleAnimation();
                da.From = rotateTransform.Angle;
                da.To = rotateTransform.Angle + 20;
                da.Duration = new Duration(TimeSpan.FromSeconds(1));
                rotateTransform.BeginAnimation(RotateTransform.AngleProperty, da);
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (UIElement elem in canvas1.Children)
            {
                if (elem is Rectangle)
                {
                    Rectangle rect = elem as Rectangle;
                    Point mousePos = e.GetPosition(rect);

                    if (mousePos.X < 0 || mousePos.Y < 0 || mousePos.X > rect.ActualWidth || mousePos.Y > rect.ActualHeight)
                    {
                        rect.Width = 40;
                        rect.Height = 80;
                        Canvas.SetLeft(rect, 20);
                        Canvas.SetTop(rect, 20);
                    }
                }
            }
        }
    }
}