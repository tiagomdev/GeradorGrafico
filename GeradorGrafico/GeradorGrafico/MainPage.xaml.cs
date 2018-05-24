using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GeradorGrafico
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = Model = new MainViewModel();

        }

        MainViewModel Model { get; set; }

        bool stop = false;
        void button1_Click(object sender, RoutedEventArgs e)
        {
            if(Secunde.SelectedIndex == -1)
            {
                var msg = new MessageDialog("Preencha o intervalo em segundos para iniciar o gráfico");
                msg.ShowAsync();
            }
            else
            {
                var secunde = (int)Secunde.Items[Secunde.SelectedIndex];

                if (!stop)
                {
                    stop = true;
                    button.Content = "Parar";
                    Model.Init(secunde);
                }
                else
                {
                    Model.Stop();
                    stop = false;
                    button.Content = "Iniciar";
                }
            }
        }
    }
}
