using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    class Database
    {
        private List<Squadra> _squadre;
        private List<Giocatore> _giocatori;
        private List<Campionato> _campionati;

        private static Database _instance;

        
        public List<Squadra> Squadre
        {
            get { return _squadre; }
            set { _squadre = value; }
        }

        public List<Campionato> Campionati
        {
            get { return _campionati; }
            set { _campionati = value; }
        }

        public List<Giocatore> Giocatori
        {
            get { return _giocatori; }
            set { _giocatori = value; }
        }

        //La classe è da considerarsi come un Singleton
        private Database()
        {
            _squadre = new List<Squadra>();
            _giocatori = new List<Giocatore>();
            _campionati = new List<Campionato>();
        }

        public Database GetInstance()
        {
            if( _instance==null)
                _instance = new Database();
            return _instance;
        }
    }
}
