using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EsMultimediale
{
    internal class CVideo : CElementoMultimediale, IRiproducibile, ILuminosita, IComparable<CVideo>, IEquatable<CVideo>
    {
        protected int Volume { get; set; }
        protected int Luminosita { get; set; }
        protected int Durata { get; set; }
        public CVideo(string titolo,int durata, int volume, int luminosita) : base(titolo)
        {
            Volume = volume;
            Luminosita = luminosita;
            Durata = durata;
        }
        public int CompareTo(CVideo altroVideo)
        {
            if (altroVideo == null)
            {
                return 1;
            }

            return Durata.CompareTo(altroVideo.Durata);
        }
        public bool Equals(CVideo altro)
        {
            if (altro == null) return false;
            return Titolo.Equals(altro.Titolo);
        }
        public string Play()
        {
            string st = "";
            for (int i = 0; i < Durata; i++)
            {
                st += "\n" +Titolo;
                for (int j = 0; j < Volume && j < 20; j++)
                {
                    st += "!";
                }
                for (int k = 0; k < Luminosita && k < 10; k++)
                {
                    st += "*";
                }
            }
            return st;
           
        }
        public override string Esegui()
        {
            return Play();
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

        public int Louder()
        {
            Volume++;
            return Volume;
        }
        public int Weaker()
        {
            Volume--;
            if (Volume < 0)
            {
                Volume = 0;
            }
            return Volume;
        }

        public override string ToString()
        {
            return base.ToString() + $",    Volume: {Volume},   Luminosita:{Luminosita},    Durata:{Durata} min";
        }
    }
}

