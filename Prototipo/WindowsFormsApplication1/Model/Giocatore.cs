using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //Descrive l'entità giocatore all'interno del sistema.
    //Inserito il controllo per evitare set di valori null nel costruttore.

    class Giocatore
    {
        private readonly String _nome;
        private readonly String _cognome;
        private readonly DateTime _dataDiNascita;
        private readonly float _altezza;
        private readonly float _peso;
        private readonly Ruolo _ruolo;

        public Giocatore( String nome, String cognome, DateTime dataDiNascita, float altezza, float peso, Ruolo ruolo )
        {
            if (nome == null)
                throw new ArgumentException("nome == null");
            if (cognome == null)
                throw new ArgumentException("cognome == null");
            if (dataDiNascita == null)
                throw new ArgumentException("dataDiNascita == null");
            if (altezza < 0)
                throw new ArgumentException("altezza < 0");
            if (peso < 0)
                throw new ArgumentException("peso < 0");
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
