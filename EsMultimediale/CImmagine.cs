using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMultimediale
{
    internal class CImmagine : CElementoMultimediale, ILuminosita
    {
        protected int Luminosita {  get; set; }

        public CImmagine(string titolo, int luminosita) : base(titolo) 
        {
            Luminosita = luminosita;
        }

        public string Show()
        {
            string st = Titolo;
            for (int i = 0; i < Luminosita; i++)
            {
                st += "*";
            }
            return st;
        }
        public override string Esegui()
        {
            return Show();
        }
        public int Brighter()
        {
            Luminosita++;
            return Luminosita;
        }
        public int Darker()
        {
            Luminosita--;
            if (Luminosita < 0)
            {
                Luminosita = 0;
            }
            return Luminosita;
        }

        public override string ToString()
        {
            return base.ToString() + $",  Luminosita: {Luminosita}";
        }
    }
}
