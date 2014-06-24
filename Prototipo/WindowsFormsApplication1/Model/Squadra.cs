using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //Descrive la struttura di una squadra.
    //E' svolto qui il controllo sui set:
    // se si tenta di settare una propietà nulla, viene lanciata una ArgumentException
    //I messaggi di errore sono customizzati.
    class Squadra
    {
        private readonly String _nome;
        private readonly String _città;
        private readonly String _impiantoDiGioco;

        //Il rooster contiene informazioni relative a più anni.
        private Dictionary<int, HashSet<Giocatore>> _rooster;

        public Squadra(String nome, String città, String impiantoDiGioco )
        {
            if( nome == null )
                throw new ArgumentException(" nome == null ");
            if( città == null)
                throw new ArgumentException(" città == null ");
            if( impiantoDiGioco == null)
                throw new ArgumentException(" impiantoDiGioco == null ");

            _nome               = nome;
            _città              = città;
            _impiantoDiGioco    = impiantoDiGioco;

            _rooster            = new Dictionary<int, HashSet<Giocatore>>();
        }

        public String Nome
        {
            get { return _nome; }
        }

        public String Città
        {
            get { return _città; }
        }

        public String Impianto
        {
            get { return _impiantoDiGioco; }
        }

        public IEnumerable<Giocatore> GetRooster(int anno)
        {
            return _rooster[anno];
        }

        //Controllo per valori null e del tipo di raccolta passata
        public void SetRooster(int anno, HashSet<Giocatore> giocatori)
        {
            if( giocatori == null || giocatori.Count == 0)
                throw new ArgumentException(" giocatori == null ");
            if( anno < 0)
                throw new ArgumentException(" anno < 0 ");

            _rooster.Add(anno, giocatori);
        }

        public override String ToString()
        {
            String result = "Nome: "+Nome+"\nCittà: "+Città+"\nRoosters: \n";

            foreach (KeyValuePair<int, HashSet<Giocatore>> pair in _rooster)
            {
                result += "Anno: " + pair.Key + "\nGiocatori: ";
                foreach (Giocatore giocatore in pair.Value)
                {

                    result += giocatore.Nome + " ";
                }
            }

            return result;
        }
    }
}
