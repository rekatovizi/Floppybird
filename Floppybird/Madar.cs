
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Floppybird
{
    public class Madar
    {
        private Image kep;

        public Madar(Image kep)
        {
            this.kep = kep;
        }

        public void Esik()
        {
            Canvas.SetTop(kep, Canvas.GetTop(kep) + 2 );
        }

        public void Ugrik()
        {
            double uj = Canvas.GetTop(kep) - 50;

            Canvas.SetTop(kep, Math.Max(0, uj));
        }

        public Rect Terulet => new Rect(
            Canvas.GetLeft(kep),
            Canvas.GetTop(kep),
            kep.ActualWidth,
            kep.ActualHeight
        );

        public double Alja => Canvas.GetTop(kep) + kep.ActualHeight;
    }
}
