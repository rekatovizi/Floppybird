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
using System.Windows.Threading;

namespace Floppybird
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        Random r = new Random();
        List<Rectangle> akadalyok = new List<Rectangle>();


        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                akadalyokhozad();
            }

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Canvas.SetTop(img_floppybird, Canvas.GetTop(img_floppybird) + 2);
            akadalymozog();
        }

        private void akadalymozog()
        {
            double canvasMagassag = jateter.ActualHeight;
            double canvasSzelesseg = jateter.ActualWidth;

            double res = 100;
            double tavolsag = canvasSzelesseg * 0.35;

            for (int i = 0; i < akadalyok.Count; i += 2)
            {
                double left = Canvas.GetLeft(akadalyok[i]);

                left -= 5;

                if (left < -60)
                {
                    double legnagyobbX = 0;

                    for (int j = 0; j < akadalyok.Count; j += 2)
                    {
                        double x = Canvas.GetLeft(akadalyok[j]);

                        if (x > legnagyobbX)
                        {
                            legnagyobbX = x;
                        }
                    }

                    left = legnagyobbX + tavolsag;

                    double min = canvasMagassag * 0.2;
                    double max = canvasMagassag - res;

                    double random = r.Next((int)min, (int)max);

                    akadalyok[i].Height = random;
                    Canvas.SetTop(akadalyok[i], 0);

                    akadalyok[i + 1].Height = canvasMagassag - random - res;
                    Canvas.SetTop(akadalyok[i + 1], random + res);
                }

                Canvas.SetLeft(akadalyok[i], left);
                Canvas.SetLeft(akadalyok[i + 1], left);
            }
        }

        private void mozog(Image img_floppybird)
        {
            double aktualispozicio = Canvas.GetTop(img_floppybird);
            double ugras = 50;
            double ujpozicio = aktualispozicio - ugras;
            if (ujpozicio < 0)
            {
                ujpozicio = 0;
            }
            Canvas.SetTop(img_floppybird, ujpozicio);
            
        }

        private void Space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                mozog(img_floppybird);
            }
        }

        private void akadalyokhozad()
        {
            Rectangle felso = new Rectangle();
            Rectangle also = new Rectangle();

            double canvasMagassag = jateter.ActualHeight;
            double canvasSzelesseg = jateter.ActualWidth;

            felso.Fill = Brushes.Green;
            also.Fill = Brushes.Green;

            felso.Width = 60;
            also.Width = 60;

            double res = 100;

            double min = canvasMagassag * 0.2;
            double max = canvasMagassag - res;

            double random = r.Next((int)min, (int)max);

            double tavolsag = canvasSzelesseg * 0.35;
            double x = canvasSzelesseg + (akadalyok.Count / 2) * tavolsag;

            felso.Height = random;
            Canvas.SetLeft(felso, x);
            Canvas.SetTop(felso, 0);

            also.Height = canvasMagassag - random - res;
            Canvas.SetLeft(also, x);
            Canvas.SetTop(also, random + res);

            jateter.Children.Add(felso);
            jateter.Children.Add(also);

            akadalyok.Add(felso);
            akadalyok.Add(also);
        }

    }

}