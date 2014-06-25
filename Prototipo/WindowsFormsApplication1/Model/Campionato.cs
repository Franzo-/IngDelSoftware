using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //Classe che rappresenta un campionato;
    //contiene informazioni relative all'anno del campionato, alle squadre che vi prendono parte, alla serie e fa riferimento
    //a un calendario.
    //Sono effettuati i controlli per prevenire il settaggio di valori nulli. 
    class Campionato
    {
        private readonly int _anno;
        private HashSet<Squadra> _squadre;
        private HashSet<Partita> _calendario;
        private List<Statistica> _statistiche;
        private readonly Serie _serie;

        public Campionato(int anno, Serie serie)
        {
            if (anno < 1900)
                throw new ArgumentException(" anno < 1900 ");

            _anno   = anno;
            _serie  = serie;
  
        }

        public int Anno
        {
            get { return _anno; }
        }

        public Serie Serie
        {
            get { return _serie; }
        }

        // Applicato il micropattern delle proprietà per evitare di lanciare eccezioni
        public HashSet<Squadra> Squadre
        {
            get { 
                if (_squadre == null)
                   _squadre = new HashSet<Squadra>();
                return _squadre; 
            }
            set { _squadre = value; }
        }

        // Applicato il micropattern delle proprietà per evitare di lanciare eccezioni
        public HashSet<Partita> Partite
        {
            get {
                if (_calendario == null)
                    _calendario = new HashSet<Partita>();
                return _calendario; 
            }
            set { _calendario = value; }
        }

        // Applicato il micropattern delle proprietà per evitare di lanciare eccezioni
        public List<Statistica> Statistiche 
        {
            get
            {
                if (_statistiche == null)
                    _statistiche = new List<Statistica>();
                return _statistiche;
            }
            set { _statistiche = value; } 
        }

        public override String ToString()
        {
            
           return Serie + " " + Anno;
            
        }
        


    }
}
