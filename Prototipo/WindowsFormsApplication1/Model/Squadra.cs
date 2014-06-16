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
        private readonly Dictionary<int, IEnumerable<Giocatore>> _rooster;

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

        public IEnumerable<Giocatore> getRooster(int anno)
        {
            return _rooster[anno];
        }

        //Controllo per valori null e del tipo di raccolta passata
        public void setRooster(int anno, HashSet<Giocatore> giocatori)
        {
            if( giocatori == null || giocatori.Count == 0)
                throw new ArgumentException(" giocatori == null ");
            if( anno == null || anno < 0)
                throw new ArgumentException(" giocatori == null ");

            _rooster.Add(anno, giocatori);
        }
    }
}
