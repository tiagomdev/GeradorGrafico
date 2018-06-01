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
            MyModel.LegendTitle = "MDI Industrial";
            Lines = new LineSeries() {
                Title = "Valor",
                Color = OxyColors.SkyBlue,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerStroke = OxyColors.White,
                MarkerFill = OxyColors.SkyBlue,
                MarkerStrokeThickness = 1.5
            };
            MyModel.Series.Add(Lines);
        }

        public List<int> Intervals => new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        DispatcherTimer sensorCollection;
        public PlotModel MyModel { get;set; }
        int x = 0;
        int y = 0;
        public List<DataPoint> Points = new List<DataPoint>();
        public LineSeries Lines { get; set; }
        public void InitChart()
        {
            Random rnd = new Random();
            x += 1;
            x = x == 500 ? 500 : x;
            y = rnd.Next(x, x*5);
            Lines.Points.Add(new DataPoint(x, y));
            MyModel.Series[0] = Lines;
            MyModel.InvalidatePlot(true);
        }

        private void sensorCollection_Tick(object sender, object e)
        {
            InitChart();
        }

        public void Init(int secundes)
        {
            sensorCollection = new DispatcherTimer();
            sensorCollection.Interval = TimeSpan.FromSeconds(secundes);
            sensorCollection.Tick += sensorCollection_Tick;
            sensorCollection.Start();
        }

        public void Stop()
        {
            sensorCollection.Stop();
        }


    }
}
