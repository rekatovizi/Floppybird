using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Floppybird
{
    public class Jatek
    {
        private Canvas palya;
        private Madar madar;
        private Random r = new Random();

        private List<AkadalyPar> akadalyok = new List<AkadalyPar>();

        private const double Sebesseg = 5;
        private const double Res = 150;

        private double Tavolsag => palya.ActualWidth * 0.35;

        public Jatek(Canvas palya, Image madarKep)
        {
            this.palya = palya;
            madar = new Madar(madarKep);

            for (int i = 0; i < 5; i++)
                UjAkadaly();
        }

        private void UjAkadaly()
        {
            double min = palya.ActualHeight * 0.2;
            double max = palya.ActualHeight - Res - min;

            double random = r.Next((int)min, (int)max);

            double x = palya.ActualWidth + akadalyok.Count * Tavolsag;

            AkadalyPar uj = new AkadalyPar(palya, x, random);

            akadalyok.Add(uj);
        }

        public void Frissites()
        {
            madar.Esik();
            AkadalyMozgas();
        }

        private void AkadalyMozgas()
        {
            foreach (AkadalyPar akadaly in akadalyok)
            {
                akadaly.Mozgat(Sebesseg);

                if (akadaly.JobbSzel < 0)
                {
                    double maxX = 0;

                    foreach (AkadalyPar masik in akadalyok)
                    {
                        if (masik.X > maxX)
                            maxX = masik.X;
                    }

                    double min = palya.ActualHeight * 0.2;
                    double max = palya.ActualHeight - Res - min;

                    double random = r.Next((int)min, (int)max);

                    akadaly.Beallitas(
                        maxX + Tavolsag,
                        random,
                        palya.ActualHeight
                    );
                }
            }
        }

        public void Ugras()
        {
            madar.Ugrik();
        }

        public bool Utkozes()
        {
            if (madar.Terulet.Top < 0 ||
                madar.Alja > palya.ActualHeight)
                return true;

            foreach (AkadalyPar akadaly in akadalyok)
            {
                if (madar.Terulet.IntersectsWith(akadaly.FelsoRect) ||
                    madar.Terulet.IntersectsWith(akadaly.AlsoRect))
                    return true;
            }

            return false;
        }
    }
}
