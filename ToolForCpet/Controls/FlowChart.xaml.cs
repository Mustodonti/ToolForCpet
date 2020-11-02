using System;
using System.Collections.Generic;
using System.Globalization;
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
using ToolForCpet.ViewModel;

namespace ToolForCpet.Controls
{
    /// <summary>
    /// Interaction logic for FlowChart.xaml
    /// </summary>
    public partial class FlowChart : UserControl
    {
        public FlowChart()
        {
            //var gi = new GraphChartInit(chartFlow, "1", new List<string> { "1", "2" });
            
            InitializeComponent();
            //var gi = new GraphChartInit(chartFlow, "wer", "1", "2", 0);
            //var gi = new GraphChartInit(chartFlow, "1", new List<string> { "Expiration", "Inspiration" });
            var md= ApplicationViewModel.GetModel();
            DataContext = md;
            //gi.AddDataXY(md.SelectedBreath.ExpirationX,md.SelectedBreath.ExpirationY.Select(i=>-i.Flow).ToList(),0);
            //gi.AddDataXY(md.SelectedBreath.InspirationX, md.SelectedBreath.InspirationY.Select(i => i.Flow).ToList(), 1);
            FormattedText text = new FormattedText("Text to display", CultureInfo.CurrentCulture,  FlowDirection.LeftToRight, new Typeface("Tahoma"), 16,  Brushes.Black);
            Geometry geometry = text.BuildGeometry(new Point(5, 5));

        }
    }
}
