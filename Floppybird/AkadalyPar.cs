
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Floppybird
{
    public class AkadalyPar
    {
        public Rectangle Felso { get; private set; }
        public Rectangle Also { get; private set; }

        private const double Szelesseg = 60;
        private const double Res = 150;

        public AkadalyPar(Canvas canvas, double x, double random)
        {
            Felso = new Rectangle
            {
                Width = Szelesseg,
                Fill = Brushes.Green
            };

            Also = new Rectangle
            {
                Width = Szelesseg,
                Fill = Brushes.Green
            };

            canvas.Children.Add(Felso);
            canvas.Children.Add(Also);

            Beallitas(x, random, canvas.ActualHeight);
        }

        public void Beallitas(double x, double random, double palyaMagassag)
        {
            Felso.Height = random;
            Also.Height = palyaMagassag - random - Res;

            Canvas.SetLeft(Felso, x);
            Canvas.SetTop(Felso, 0);

            Canvas.SetLeft(Also, x);
            Canvas.SetTop(Also, random + Res);
        }

        public void Mozgat(double sebesseg)
        {
            double x = Canvas.GetLeft(Felso) - sebesseg;

            Canvas.SetLeft(Felso, x);
            Canvas.SetLeft(Also, x);
        }

        public double X => Canvas.GetLeft(Felso);

        public double JobbSzel => X + Szelesseg;

        public Rect FelsoRect => new Rect(
            X, Canvas.GetTop(Felso),
            Felso.Width, Felso.Height
        );

        public Rect AlsoRect => new Rect(
            X, Canvas.GetTop(Also),
            Also.Width, Also.Height
        );
    }
}

