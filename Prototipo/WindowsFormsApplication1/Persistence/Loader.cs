using BasketSystem.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BasketSystem.Persistence
{
    class Loader : ILoader
    {
        public void Load()
        {
            Database database = Database.GetInstance();

            //E' possibile salvare direttamente i dati all'interno degli oggetti di Database
            //Perchè l'abbiamo pensato come Singleton, quindi istanza unica.

            LoadGiocatori(database);
            //LoadSquadre(database);
            //database.Campionati = LoadCampionati();
        }

        private void LoadGiocatori( Database database )
        {
            //File xml dei giocatori
            String filename = "../../Dati/giocatori.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            //Non so se va bene qui o lo posso mettere all'interno del ciclo
            Giocatore giocatore = null;

            //Scarto i commenti
            foreach (XmlElement giocatoreNode in xmlDocument.SelectNodes("/Giocatori/giocatore"))
            {
                //
                try
                {
                    String cognome = giocatoreNode.SelectSingleNode("cognome").InnerText;
                    String nome = giocatoreNode.SelectSingleNode("nome").InnerText;
                    DateTime dateTime = DateTime.Parse(giocatoreNode.SelectSingleNode("nascita").InnerText,
                        CultureInfo.CreateSpecificCulture("it-IT"));
                    int peso = Int16.Parse(giocatoreNode.SelectSingleNode("peso").InnerText);
                    int altezza = Int16.Parse(giocatoreNode.SelectSingleNode("altezza").InnerText);
                    Ruolo ruolo = (Ruolo)Enum.Parse(typeof(Ruolo), giocatoreNode.SelectSingleNode("ruolo").InnerText);

                    giocatore = new Giocatore(nome, cognome, dateTime, altezza, peso, ruolo);

                    Console.WriteLine(giocatore.ToString());

                    database.Giocatori.Add(giocatore);

                    Console.WriteLine(database.Giocatori.Count);
                }
                catch (Exception e)
                {
                }
            }
        }

        private void LoadSquadre( Database database )
        {
            //File xml delle squadre
        }

        private Dictionary<int, HashSet<Giocatore>> LoadRoster()
        {
            throw new NotImplementedException();
        }

        private HashSet<Campionato> LoadCampionati()
        {
            throw new NotImplementedException();
        }
    }
}
