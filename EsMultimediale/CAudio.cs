using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMultimediale
{
    internal class CAudio : CElementoMultimediale, IRiproducibile
    {
        protected int Durata {  get; set; }
        protected int Volume {  get; set; }
        public CAudio(string titolo, int durata, int volume) : base(titolo)
        {
            Durata = durata;
            Volume = volume;
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
        public string Play()
        {
            string str = "";
            for (int i = 0; i<Durata; i++)
            {
                str += "\n" + Titolo;
                for (int j= 0; j < Volume; j++)
                {
                    str += "!";
                }
            }
            return str;
        }
        public override string Esegui()
        {
            return Play();
        }

        public override string ToString()
        {
            return base.ToString() + $",    Durata: {Durata}min,      Volume: {Volume}";
        }
    }
}
