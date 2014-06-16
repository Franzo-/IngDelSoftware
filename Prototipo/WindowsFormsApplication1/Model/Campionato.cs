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
        private readonly Serie _serie;

        public Campionato(int anno, Serie serie)
        {
            if (anno == null)
                throw new ArgumentException(" anno == null ");
            if (serie == null)
                throw new ArgumentException(" serie == null ");

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

        public HashSet<Squadra> Squadre
        {
            get { return _squadre; }
            set 
            {
                if (value == null)
                    throw new ArgumentException(" _squadre == null ");
                _squadre = value; 
            }
        }

        public HashSet<Partita> Partite
        {
            get { return _calendario; }
            set 
            {
                if (value == null)
                    throw new ArgumentException(" _calendario == null ");
                _calendario = value; 
            }
        }



        //Utility


    }
}
