using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EsMultimediale
{
    internal class Program
    {
        public static CElementoMultimediale[] elementi = new CElementoMultimediale[5];

        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!");

            for (int i = 0; i < 5; i++)
            {
                int scelta;
                do
                {
                    Console.WriteLine("Scegli cosa aggiungere:");
                    Console.WriteLine("1. Audio");
                    Console.WriteLine("2. Video");
                    Console.WriteLine("3. Immagine");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 3);

                switch (scelta)
                {
                    case 1:
                        elementi[i] = new CAudio(InputStringa("titolo"), InputNumero("Durata: ",0, 2000), InputNumero("Volume: ", 0, 20));
                        Console.WriteLine("Audio aggiunto correttamente");
                        break;
                    case 2:
                        elementi[i] = new CVideo(InputStringa("titolo"), InputNumero("Durata: ", 0, 2000), InputNumero("Volume: ", 0, 20), InputNumero("Luminosità: ", 0, 10));
                        Console.WriteLine("Video aggiunto correttamente");
                        break;
                    case 3:
                        elementi[i] = new CImmagine(InputStringa("titolo"), InputNumero("Luminosità: ", 0, 10));
                        Console.WriteLine("Immagine aggiunta correttamente");
                        break;
                    default:
                        Console.WriteLine("Errore");
                        return;
                }

            }

            do
            {
                int scelta;
                Console.WriteLine("1. Esegui");
                Console.WriteLine("2. Regola");
                Console.WriteLine("3. Video piu brevi");
                Console.WriteLine("4. Ordina per titolo");
                Console.WriteLine("5. Controllo uguaglianza video");
                Console.WriteLine("6. Esci");
                do
                {
                    Console.WriteLine("Scegli opzione");
                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 1 || scelta > 6);

                switch (scelta)
                {
                    case 1:
                        Esegui();
                        break;
                    case 2:
                        Regola();
                        break;
                    case 3:
                        VideoPiuBrevi();
                        break;
                    case 4:
                        OrdinaPerTitolo();
                        break;
                    case 5:
                        ControlloUguaglianzaVideo();
                        break;
                    case 6:
                        Console.WriteLine("Uscita dal programma...");
                        return;
                    default:
                        Console.WriteLine("Errore");
                        break;
                }
            } while (true);

        }
        public static string InputStringa(string par)
        {
            string st;
            do
            {
                Console.WriteLine("Scrivi " + par);
                st = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(st));

            return st;
        }

        public static int InputNumero(string mes, int min, int max)
        {
            int n;
            do
            {
                Console.WriteLine(mes);
            } while (!int.TryParse(Console.ReadLine(), out n) || n < min || n > max);
            return n;
        }

        public static int Scelta()
        {
            Console.WriteLine("Oggetti: ");
            for (int i = 0; i < elementi.Length; i++)
            {
                Console.WriteLine((i + 1) + ") " + elementi[i].ToString());
            }

            int sc;
            do
            {
                Console.WriteLine("Quale oggetto scegli 1-5?");
            } while (!int.TryParse(Console.ReadLine(), out sc) || sc < 1 || sc > 5);
            return sc;
        }

        public static void Esegui()
        {
            int sc = Scelta();
            Console.WriteLine(elementi[sc - 1].Esegui());
        }
        public static void Regola()
        {
            Console.WriteLine("Scegli oggetto da regolare");
            int sc = Scelta();

            bool regolabile = false;
            if (elementi[sc - 1] is ILuminosita l)
            {
                regolabile = true;
                Console.WriteLine("Regolazione luminosità");
                int sceltaLum;
                do
                {
                    Console.WriteLine("1. Aumenta luminosità");
                    Console.WriteLine("2. Diminuisci luminosità");
                } while (!int.TryParse(Console.ReadLine(), out sceltaLum) || sceltaLum < 1 || sceltaLum > 2);
                if (sceltaLum == 1)
                {
                    l.Brighter();
                }
                else
                {
                    l.Darker();
                }
            }

            if (elementi[sc - 1] is IRiproducibile r)
            {
                regolabile = true;
                Console.WriteLine("Regolazione volume");
                int sceltaVol;
                do
                {
                    Console.WriteLine("1. Aumenta volume");
                    Console.WriteLine("2. Diminuisci volume");
                } while (!int.TryParse(Console.ReadLine(), out sceltaVol) || sceltaVol < 1 || sceltaVol > 2);
                if (sceltaVol == 1)
                {
                    r.Louder();
                }
                else
                {
                    r.Weaker();
                }
            }

            if (!regolabile)
            {
                Console.WriteLine("L'oggetto scelto non è regolabile");
                return;
            }

            Console.WriteLine(elementi[sc - 1].ToString());

        }
        public static void VideoPiuBrevi()
        {
            if (!ContaVideo())
            {
                Console.WriteLine("Non ci sono video");
                return;
            }
            int sc;
            bool trovato = false;
            do
            {
                Console.WriteLine("Visualizzazione video con durata inferiore");
                sc = Scelta();
            } while (!(elementi[sc - 1] is CVideo));

            CVideo videoPar = (CVideo)elementi[sc - 1];
            for (int i = 0; i < elementi.Length; i++)
            {
                if (elementi[i] is CVideo v && v.CompareTo(videoPar) < 0)
                {
                    Console.WriteLine(v.ToString());
                    trovato = true;
                }

            }
            if (!trovato)
            {
                Console.WriteLine("Non ci sono video con durata inferiore a " + videoPar.ToString());
            }
        }
        public static void OrdinaPerTitolo()
        {
            Console.WriteLine("Elementi ordinati per titolo:");
            Array.Sort(elementi);

            for (int i = 0; i < elementi.Length; i++)
            {
                Console.WriteLine(elementi[i].ToString());
            }

        }
        public static void ControlloUguaglianzaVideo()
        {
            if(!ContaVideo())
            {
                Console.WriteLine("Non ci sono video");
                return;
            }
            Console.WriteLine("Controllo uguaglianza due video");
            int n1, n2;
            do
            {
                Console.WriteLine("Inserisci numero primo video");
                n1 = Scelta();
            } while (!(elementi[n1 - 1] is CVideo));
            do
            {
                Console.WriteLine("Inserisci numero secondo video");
                n2 = Scelta();
            } while (!(elementi[n2 - 1] is CVideo));

            CVideo v1 = (CVideo)elementi[n1 - 1];
            CVideo v2 = (CVideo)elementi[n2 - 1];

            if (v1.Equals(v2))
            {
                Console.WriteLine("I due video sono uguali");
            }
            else
            {
                Console.WriteLine("I due video sono diversi");
            }

        }
        public static bool ContaVideo()
        {
            foreach(var elemento in elementi)
            {
                if (elemento is CVideo) return true;
            }
            return false;
        }
    }
}

    
