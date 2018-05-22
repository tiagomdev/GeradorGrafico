using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Devices.Input;
using Windows.UI.Xaml;

namespace GeradorGrafico
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            MyModel = new PlotModel();
            Lines = new LineSeries() {
                Title = "GeradorGrafico",
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5
            };
            MyModel.Series.Add(Lines);
        }
        public ICommand InitChartCommand { get; set; }
        public PlotModel MyModel { get;set; }
        public int x = 1;
        public int y = 5;
        public List<DataPoint> Points = new List<DataPoint>();
        public LineSeries Lines { get; set; }
        public void InitChart()
        {
            Task.Delay(TimeSpan.FromSeconds(5)).Wait();
            x += 5;
            y += 5;
            Lines.Points.Add(new DataPoint(x, y));
            MyModel.Series[0] = Lines;
        }

        
    }
}
