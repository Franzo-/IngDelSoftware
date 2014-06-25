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
            LoadSquadre(database);
            LoadCampionati(database);
        }

        private void LoadGiocatori( Database database )
        {
            //File xml dei giocatori
            String filename = "../../Dati/giocatori.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);


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

                    Giocatore giocatore = new Giocatore(nome, cognome, dateTime, altezza, peso, ruolo);

                    //Console.WriteLine(giocatore.ToString());

                    database.Giocatori.Add(giocatore);

                    //Console.WriteLine(database.Giocatori.Count);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void LoadSquadre( Database database )
        {
            //File xml delle squadre
            String filename = "../../Dati/squadre.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            foreach (XmlElement squadraNode in xmlDocument.SelectNodes("/Squadre/Squadra"))
            {
                try
                {
                    String nome = squadraNode.SelectSingleNode("nome").InnerText;
                    String citta = squadraNode.SelectSingleNode("citta").InnerText;
                    String impianto = squadraNode.SelectSingleNode("impianto").InnerText;

                    Squadra squadra = new Squadra(nome, citta, impianto);

                    Dictionary<int, HashSet<Giocatore>> roster = LoadRoster(nome, database);
                    foreach (KeyValuePair<int, HashSet<Giocatore>> pair in roster)
                    {
                        squadra.SetRooster(pair.Key, pair.Value);
                    }
                    Console.WriteLine(squadra.ToString());
                    database.Squadre.Add(squadra);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        //Non è ottimizzato, ma così è comodo
        private Dictionary<int, HashSet<Giocatore>> LoadRoster( String nome, Database database )
        {
            //File xml dei Roster
            String filename = "../../Dati/roster.xml";

            Dictionary<int, HashSet<Giocatore>> result = new Dictionary<int, HashSet<Giocatore>>();
            int anno = 0;
            HashSet<Giocatore> giocatori = null;

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            foreach (XmlElement rosterNode in xmlDocument.SelectNodes("/Rosters/Roster"))
            {
                String nomeSquadra = rosterNode.SelectSingleNode("squadra").InnerText;

                if (!nomeSquadra.Equals(nome))
                    continue;
                else
                {
                    anno = Int16.Parse(rosterNode.SelectSingleNode("anno").InnerText);
                    giocatori = new HashSet<Giocatore>();

                    //Carico tutti i giocatori del Roster
                    XmlNode giocatoriNode =  rosterNode.SelectSingleNode("giocatori");

                    foreach (XmlNode giocatoreNode in giocatoriNode.ChildNodes)
                    {
                        String giocatore = giocatoreNode.InnerText;

                        //Ciclo su tutti i giocatori e cerco quello giusto
                        foreach (Giocatore g in database.Giocatori)
                        {
                            if (!g.Cognome.Equals(giocatore))
                                continue;
                            else 
                            {
                                giocatori.Add(g);
                            }
                        }
                    }
                }
                result.Add(anno, giocatori);
            }

            
            return result;
        }

        private void LoadCampionati( Database database)
        {
            //File xml dei Campionati
            String filename = "../../Dati/campionati.xml";

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(filename);

            foreach(XmlElement campionatoNode in xmlDocument.SelectNodes("/Campionati/Campionato"))
            {
                try
                {
                    int anno = Int16.Parse(campionatoNode.SelectSingleNode("anno").InnerText);
                    Serie serie = (Serie) Enum.Parse(typeof(Serie), campionatoNode.SelectSingleNode("serie").InnerText);
                    

                    Campionato campionato = new Campionato(anno, serie);

                    //POPOLAMENTO SQUARDE
                    XmlNode squadreNode = campionatoNode.SelectSingleNode("Squadre");
                    HashSet<Squadra> squadre = new HashSet<Squadra>();

                    foreach (XmlNode squadra in squadreNode.ChildNodes)
                    {
                        foreach (Squadra s in database.Squadre)
                        {
                            if (squadra.InnerText.Equals(s.Nome))
                            {
                                squadre.Add(s);
                            }
                        }
                    }

                    campionato.Squadre = squadre;

                    //POPOLAMENTO PARTITE
                    XmlNode partiteNode = campionatoNode.SelectSingleNode("Partite");
                    HashSet<Partita> partite = new HashSet<Partita>();
                    foreach(XmlNode partita in partiteNode.ChildNodes)
                    {

                            int giornata = Int16.Parse(partita.SelectSingleNode("giornata").InnerText);
                            int puntiCasa = Int16.Parse(partita.SelectSingleNode("puntiCasa").InnerText);
                            int puntiOspite = Int16.Parse(partita.SelectSingleNode("puntiOspite").InnerText);
                            DateTime data = DateTime.Parse(partita.SelectSingleNode("data").InnerText, 
                                CultureInfo.CreateSpecificCulture("it-IT"));

                            String casa = partita.SelectSingleNode("casa").InnerText;
                            Squadra squadraCasa = null;

                            foreach (Squadra s in database.Squadre)
                            {
                                if (casa.Equals(s.Nome))
                                {
                                    squadraCasa = s;
                                }
                            }


                            String ospite = partita.SelectSingleNode("ospite").InnerText;
                            Squadra squadraOspite = null;

                            foreach (Squadra s in database.Squadre)
                            {
                                if (ospite.Equals(s.Nome))
                                {
                                    squadraOspite = s;
                                }
                            }

                            Partita match = new Partita(data, giornata, puntiOspite, puntiCasa, squadraCasa, squadraOspite);
                            partite.Add(match);
                    }
                    campionato.Partite = partite;

                    //POPOLAMENTO STATISTICHE
                    //Qui c'è il macello, leggi bene.

                    GeneraStatSquadra(campionato);

                    foreach (Partita partita in campionato.Partite)
                    {
                        
                            foreach(Giocatore giocatore in partita.Casa.GetRooster(campionato.Anno) )
                            {
                                GeneraStatisticheRandom(partita, giocatore, campionato);
                            }
                            foreach (Giocatore giocatore in partita.Ospite.GetRooster(campionato.Anno))
                            {
                                GeneraStatisticheRandom(partita, giocatore, campionato);
                            }
                        
                    }

                    campionato.ToString();
                    database.Campionati.Add(campionato);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void GeneraStatSquadra( Campionato campionato)
        {
            Dictionary<Squadra, int[]> tempStatistiche = new Dictionary<Squadra, int[]>();

            foreach (Squadra squadra in campionato.Squadre)
            {
                tempStatistiche.Add(squadra, new int[] { 0, 0, 0, 0 });
            }

            foreach (Partita partita in campionato.Partite)
            {
                Squadra vincitrice = (partita.PuntiCasa - partita.PuntiOspite > 0) ? partita.Casa : partita.Ospite;
                Squadra perdente = (partita.PuntiCasa - partita.PuntiOspite < 0) ? partita.Casa : partita.Ospite;

                //Vincitrice
                int[] stat = tempStatistiche[vincitrice];
                int[] newStat = new int[] { stat[0] + 2, stat[1] + 1, stat[2] + 1, stat[3] };
                tempStatistiche[vincitrice] = newStat;

                //Perdente
                stat = tempStatistiche[perdente];
                newStat = new int[] { stat[0], stat[1] + 1, stat[2], stat[3] + 1 };
                tempStatistiche[perdente] = newStat;
            }

            foreach (KeyValuePair<Squadra, int[]> tempStat in tempStatistiche)
            {
                campionato.Statistiche.Add(new StatisticaSquadra(tempStat.Key, tempStat.Value[0], tempStat.Value[1], tempStat.Value[2], tempStat.Value[3]));
            }
        }

        private void GeneraStatisticheRandom( Partita partita, Giocatore giocatore, Campionato campionato)
        {
            Random _random = new Random(); 

            int punti = _random.Next(0, partita.PuntiCasa);
            int tent2Tot = _random.Next(20);
            int tent2Segn = _random.Next(tent2Tot);
            int tent3Tot = _random.Next(20);
            int tent3Segn = _random.Next(tent3Tot);
            int tlTot = _random.Next(10);
            int tlSegn = _random.Next(tlTot);
            int palleRec = _random.Next(20);
            int minGioc = _random.Next(40);

            StatisticaGiocatore stat =  new StatisticaGiocatore(
                partita,
                giocatore,
                punti,
                tent2Segn,
                tent2Tot,
                tent3Segn,
                tent3Tot,
                tlSegn,
                tlTot,
                palleRec,
                minGioc
                );

            campionato.Statistiche.Add(stat);
        }
    }
}
