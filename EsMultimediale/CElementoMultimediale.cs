using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMultimediale
{
    abstract class CElementoMultimediale : IComparable<CElementoMultimediale>
    {
        protected string Titolo { get; set;  }

        public CElementoMultimediale(string Titolo)
        {
            this.Titolo = Titolo;
        }

        public abstract string Esegui();
        public override string ToString()
        {
            return $"Titolo: {Titolo}";
        }
        public int CompareTo(CElementoMultimediale altro)
        {
            return Titolo.CompareTo(altro.Titolo);
        }
    }
}
