
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Floppybird
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Jatek jatek;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            jatek = new Jatek(jateter, img_floppybird);

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(16)
            };

            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            jatek.Frissites();

            if (jatek.Utkozes())
            {
                timer.Stop();
                MessageBox.Show("Vesztettél!");
                Application.Current.Shutdown();
            }
        }

        private void Space(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space && timer.IsEnabled)
                jatek.Ugras();
        }
    }
}