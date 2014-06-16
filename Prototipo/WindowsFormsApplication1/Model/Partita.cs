﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //Classe atta alla definizione dell'oggetto partita.
    //Inserito il controllo per evitare il settaggio di valori nulli.
    class Partita
    {
        private readonly DateTime _data;
        private readonly int _giornata;
        private readonly int _puntiOspite;
        private readonly int _puntiCasa;
        private readonly Squadra _casa;
        private readonly Squadra _ospite;

        public Partita( DateTime data, int giornata, int puntiOspite, int puntiCasa, Squadra casa, Squadra ospite )
        {
            if (data == null)
                throw new ArgumentException(" data == null ");
            if (giornata == null)
                throw new ArgumentException(" giornata == null ");
            if (puntiOspite == null)
                throw new ArgumentException(" puntiOspite == null ");
            if (puntiCasa == null)
                throw new ArgumentException(" puntiCasa == null ");
            if (casa == null)
                throw new ArgumentException(" casa == null ");
            if (ospite == null)
                throw new ArgumentException(" ospite == null ");

            _data           = data;
            _giornata       = giornata;
            _puntiOspite    = puntiOspite;
            _puntiCasa      = puntiCasa;
            _casa           = casa;
            _ospite         = ospite;

        }

        public DateTime Data
        {
            get { return _data; }
        }

        public int Giornata
        {
            get { return _giornata; }
        }

        public int PuntiOspite
        {
            get { return _puntiOspite; }
        }

        public int PuntiCasa
        {
            get { return _puntiCasa; }
        }

        public Squadra Casa
        {
           get { return _casa; }
        }

        public Squadra Ospite
        {
            get { return _ospite; }
        }
    }
}
