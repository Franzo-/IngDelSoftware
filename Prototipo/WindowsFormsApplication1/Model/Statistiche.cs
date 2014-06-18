﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    //TODO: deve essere comparabile
    //struct CampoStatistica<T>
    //    where T : IComparable
    //{
    //    private readonly string _nomeCampo;
    //    private readonly T _campo;

    //    public CampoStatistica(string nome, T campo)
    //    {
    //        if (nome == null)
    //            throw new ArgumentException("nome == null");
    //        if (campo == null)
    //            throw new ArgumentException("campo == null");

    //        _nomeCampo = nome;
    //        _campo = campo;
    //    }

    //    public string Nome
    //    {
    //        get { return _nomeCampo; }
    //    }

    //    public T Campo
    //    {
    //        get { return _campo; }
    //    } 

    //}

    struct CampoStatistica
    {
        private readonly string _nomeCampo;
        private readonly IComparable _campo;

        public CampoStatistica(string nome, IComparable campo)
        {
            if (nome == null)
                throw new ArgumentException("nome == null");
            if (campo == null)
                throw new ArgumentException("campo == null");

            _nomeCampo = nome;
            _campo = campo;
        }

        public string Nome
        {
            get { return _nomeCampo; }
        }

        public IComparable Campo
        {
            get { return _campo; }
        }

    }

    abstract class Statistica : ICloneable
    {
        private Dictionary<string, CampoStatistica> _campi;

        //Accessor utilizzabile solo dalle classi derivate
        protected Dictionary<string, CampoStatistica> Campi
        {
            get {
                if (_campi == null)
                    _campi = new Dictionary<string, CampoStatistica>();
                return _campi; 
            }
            set { _campi = value; }
        }

        public CampoStatistica GetCampo(string nome)
        {
            if (nome == null)
                throw new ArgumentException("nome == null");

            return Campi[nome];
        }

        public void SetCampo(string nome, CampoStatistica campo)
        {
            if (nome == null)
                throw new ArgumentException("nome == null");

            Campi[nome] = campo;
        }

        //Restituisce i nomi dei campi per popolare la GUI
        public String[] GetNomiCampi()
        {
            return Campi.Keys.ToArray<String>();
        }

        public void Accept(ICalcoloVisitor visitor, string metodo)
        {
            visitor.Visit(this, metodo);
        }

        #region IClonable

        abstract public object Clone();

        //Deep copy del dizionario
        protected Dictionary<string, CampoStatistica> CampiClone()
        {
            Dictionary<string, CampoStatistica> newDict = new Dictionary<string, CampoStatistica>();
            foreach (KeyValuePair<string, CampoStatistica> item in this.Campi)
            {
                newDict.Add(item.Key, new CampoStatistica(item.Value.Nome, item.Value.Campo));
            }
            return newDict;
        }

        #endregion

    }

    class StatisticaSquadra : Statistica
    {
        private readonly Squadra _squadra;

        //private int anno;     //anno è sottointeso se le statistiche si trovano dentro a Campionato

        public StatisticaSquadra(int punti, Squadra squadra, int partiteGiocate, int partiteVinte, int partitePerse)
        {
            if (punti < 0)
                throw new ArgumentException("punti < 0 ");
            if (squadra == null)
                throw new ArgumentException("squadra == null");
            if (partiteGiocate < 0)
                throw new ArgumentException("partiteGiocate < 0");
            if (partiteVinte < 0)
                throw new ArgumentException("partiteVinte < 0");
            if (partitePerse < 0)
                throw new ArgumentException("partitePerse < 0");

            _squadra = squadra;

            SetCampo("Punti", new CampoStatistica("Punti", punti));
            SetCampo("Partite Giocate", new CampoStatistica("Partite Giocate", partiteGiocate));
            SetCampo("Partite Vinte", new CampoStatistica("Partite Vinte", partiteVinte));
            SetCampo("Partite Perse", new CampoStatistica("Partite Perse", partitePerse));
            
        }

        public Squadra Squadra 
        {
            get { return _squadra; }
        }

        #region IClonable
        public override object Clone()
        {
            //Shallow copy dei riferimenti
            StatisticaSquadra newStatistica = (StatisticaSquadra)this.MemberwiseClone();

            //Deep copy del dizionario
            newStatistica.Campi = CampiClone();

            return newStatistica;
        } 
        #endregion
    }

    class StatisticaGiocatore : Statistica
    {

        private readonly Partita _partita;
        private readonly Giocatore _giocatore;

        public StatisticaGiocatore(int punti, Partita partita, Giocatore giocatore, int tent2segn, int tent2tot, int tent3segn, int tent3tot, int tlSegn, int tlTot, int palleRec, int minGiocati)
        {
            if (punti < 0 )
                throw new ArgumentException("punti < 0 ");
            if (partita == null)
                throw new ArgumentException("partita == null");
            if (giocatore == null)
                throw new ArgumentException("giocatore == null");
            if (tent2segn < 0)
                throw new ArgumentException("tent2segn < 0");
            if (tent2tot < 0)
                throw new ArgumentException("tent2tot < 0");
            if (tent3segn < 0)
                throw new ArgumentException("tent3segn < 0");
            if (tent3tot < 0)
                throw new ArgumentException("tent3tot < 0");
            if (tlSegn < 0)
                throw new ArgumentException("tlSegn < 0");
            if (tlTot < 0)
                throw new ArgumentException("tlTot < 0");
            if (palleRec < 0)
                throw new ArgumentException("palleRec < 0");
            if (minGiocati < 0)
                throw new ArgumentException("minGiocati < 0");

            _partita = partita;
            _giocatore = giocatore;

            SetCampo("Punti", new CampoStatistica("Punti", punti));
            SetCampo("Tentativi da 2 Segnati", new CampoStatistica("Tentativi da 2 Segnati", tent2segn));
            SetCampo("Tentativi da 2 Totali", new CampoStatistica("Tentativi da 2 Totali", tent2tot));
            SetCampo("Tentativi da 3 Segnati", new CampoStatistica("Tentativi da 3 Segnati", tent3segn));
            SetCampo("Tentativi da 3 Totali", new CampoStatistica("Tentativi da 3 Totali", tent3tot));
            SetCampo("Tiri Liberi Segnati", new CampoStatistica("Tiri Liberi Segnati", tlSegn));
            SetCampo("Tiri Liberi Totali", new CampoStatistica("Tiri Liberi Totali", tlTot));
            SetCampo("Palle Recuperate", new CampoStatistica("Palle Recuperate", palleRec));
            SetCampo("Minuti Giocati", new CampoStatistica("Minuti Giocati", minGiocati));

        }

        public Partita Partita
        {
            get { return _partita; }
        }

        public Giocatore Giocatore
        {
            get { return _giocatore; }
        }

        #region IClonable
        public override object Clone()
        {
            //Shallow copy dei riferimenti
            StatisticaGiocatore newStatistica = (StatisticaGiocatore)this.MemberwiseClone();

            //Deep copy del dizionario
            newStatistica.Campi = CampiClone();

            return newStatistica;
        } 
        #endregion
    }
}
