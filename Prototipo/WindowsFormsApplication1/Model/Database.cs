using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    class Database
    {
        private HashSet<Squadra> _squadre;
        private HashSet<Giocatore> _giocatori;
        private HashSet<Campionato> _campionati;

        private static Database _instance;


        //La classe è da considerarsi come un Singleton
        private Database()
        {
            _squadre = new HashSet<Squadra>();
            _giocatori = new HashSet<Giocatore>();
            _campionati = new HashSet<Campionato>();
        }

        public static Database GetInstance()
        {
            if (_instance == null)
                _instance = new Database();
            return _instance;
        }

        
        public HashSet<Squadra> Squadre
        {
            get { return _squadre; }
            set { _squadre = value; }
        }

        public HashSet<Campionato> Campionati
        {
            get { return _campionati; }
            set { _campionati = value; }
        }

        public HashSet<Giocatore> Giocatori
        {
            get { return _giocatori; }
            set { _giocatori = value; }
        }

    }
}
