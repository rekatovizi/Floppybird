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
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(5);
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
            Canvas.SetLeft(r_top, Canvas.GetLeft(r_top) - 5);
            Canvas.SetLeft(r_bottom, Canvas.GetLeft(r_bottom) - 5);
            if (Canvas.GetLeft(r_top) < -100)
            {
                Canvas.SetLeft(r_top, 800);
                Canvas.SetLeft(r_bottom, 800);
                double random = r.Next(100, 400);
                
            }

        }

        private void mozog(Image img_floppybird)
        {
            double aktualispozicio = Canvas.GetTop(img_floppybird);
            double ugras = 50;
            double ujpozicio = aktualispozicio - ugras;
            Canvas.SetTop(img_floppybird, ujpozicio);
        }

        private void Space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                mozog(img_floppybird);
            }
        }


    }

    

}