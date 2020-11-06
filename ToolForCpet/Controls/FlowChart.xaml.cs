using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
using ToolForCpet.ViewModel;

namespace ToolForCpet.Controls
{
    /// <summary>
    /// Interaction logic for FlowChart.xaml
    /// </summary>
    public partial class FlowChart : UserControl
    {
        ApplicationViewModel md;
        Line line;
        public FlowChart()
        {
            InitializeComponent();
            md = ApplicationViewModel.GetModel();
            DataContext = md;
        }

        Line prevLine = new Line();
        ToolTip prevTltp=new ToolTip();
        ToolTip tltp = new ToolTip();
        private void FlowCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            //Line line = new Line();
            Point p = Mouse.GetPosition(FlowCanvas);
            line.Visibility = Visibility.Visible;
            line.X1 = p.X;
            line.X2 = p.X;
            line.Y1 = 0;
            line.Y2 = 200;
            var lst = md.LinesFlow.Select(i => Math.Round(i.From.X)).ToList();
            var indFrom = lst.IndexOf(line.X1);
            var lst2 = md.LinesFlow.Select(i => Math.Round(i.To.X)).ToList();
            var indTo = lst2.IndexOf(line.X1);

            if (!(indFrom==-1))
            {
                prevTltp.IsOpen = false;
                tltp = new ToolTip { Content = $"{md.LinesFlow[indFrom].FromX}\n {md.LinesFlow[indFrom].FromY}", IsOpen = true };
                line.ToolTip = tltp;
                prevTltp = tltp;
            }
            else if (!(indTo == -1))
            {
                prevTltp.IsOpen = false;
                tltp = new ToolTip { Content = $"{md.LinesFlow[indTo].ToX}\n {md.LinesFlow[indTo].ToY}", IsOpen = true };
                line.ToolTip = tltp;
                prevTltp = tltp;
            }
            prevLine = line;
        }

        private void FlowCanvas_MouseLeave(object sender, MouseEventArgs e)
        {
            prevTltp.IsOpen = false;
            line.Visibility= Visibility.Hidden;
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
    where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void Line_Loaded(object sender, RoutedEventArgs e)
        {
            line = sender as Line;
            line.Stroke = Brushes.Green;
            line.StrokeThickness = 2;

        }
    }
}
