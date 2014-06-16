using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //Descrive l'entità giocatore all'interno del sistema.
    //Inserito il controllo per evitare set di valori null nel costruttore.

    //Si possono fare altri controlli (numeri devono essere maggiori di 0, lunghezza stringhe != 0),
    //Ma tanto è un prototipo, quindi ciccia.
    class Giocatore
    {
        private String _nome;
        private String _cognome;
        private DateTime _dataDiNascita;
        private float _altezza;
        private float _peso;
        private Ruolo _ruolo;

        public Giocatore( String nome, String cognome, DateTime dataDiNascita, float altezza, float peso, Ruolo ruolo )
        {
            if (nome == null)
                throw new ArgumentException("nome == null");
            if (cognome == null)
                throw new ArgumentException("cognome == null");
            if (dataDiNascita == null)
                throw new ArgumentException("dataDiNascita == null");
            if (altezza == null)
                throw new ArgumentException("altezza == null");
            if (peso == null)
                throw new ArgumentException("peso == null");
            if (ruolo == null)
                throw new ArgumentException("ruolo == null");

            _nome           = nome;
            _cognome        = cognome;
            _dataDiNascita  = dataDiNascita;
            _altezza        = altezza;
            _peso           = peso;
            _ruolo          = ruolo;
        }

        public String Nome
        {
            get { return _nome; }
        }

        public String Cognome
        {
            get { return _cognome; }
        }

        public DateTime DataDiNascita
        {
            get { return _dataDiNascita; }
        }

        public float Peso
        {
            get { return _peso; }
        }

        public float Altezza
        {
            get { return _altezza; }
        }

        public Ruolo Ruolo
        {
            get { return _ruolo; }
        }
    }
}
