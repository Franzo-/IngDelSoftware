using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{

    struct CampoStatistica : IComparable 
    {
        private readonly ValueType _campo;

        public CampoStatistica(ValueType campo)
        {
            if (!(campo is IComparable && (campo.GetType().IsPrimitive || campo.GetType().IsValueType)))
                throw new ArgumentException("!(campo is IComparable && (campo.GetType().IsPrimitive " +
                    "|| campo.GetType().IsValueType))");

            _campo = campo;
        }

    #region Operatori 

        //Ridefinisce l'operatore + per oggetti CampoStatistica
        public static CampoStatistica operator +(CampoStatistica a, CampoStatistica b)
        {
            return new CampoStatistica((dynamic)a.Campo + (dynamic)b.Campo);
        }

        //Ridefinisce l'operatore - per oggetti CampoStatistica
        public static CampoStatistica operator -(CampoStatistica a, CampoStatistica b)
        {
            return new CampoStatistica((dynamic)a.Campo - (dynamic)b.Campo);
        }

        //Ridefinisce l'operatore * per oggetti CampoStatistica
        public static CampoStatistica operator *(CampoStatistica a, CampoStatistica b)
        {
            return new CampoStatistica((dynamic)a.Campo * (dynamic)b.Campo);
        }

        //Ridefinisce l'operatore / per oggetti CampoStatistica
        public static CampoStatistica operator /(CampoStatistica a, CampoStatistica b)
        {
            return new CampoStatistica(((dynamic)a.Campo * 1.0)/ (dynamic)b.Campo);
        }

        #endregion

        public ValueType Campo
        {
            get { return _campo; }
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;
            if (!(obj is CampoStatistica))
                throw new ArgumentException();

            CampoStatistica cs = (CampoStatistica)obj;

            //Prima casto a CampoStatistica e dopo ad IComparable perchè devo estrarre il campo
            return ((IComparable)Campo).CompareTo((IComparable)cs.Campo);
        }

        public override string ToString()
        {
            //return ((IFormattable) _campo).ToString("F2", CultureInfo.CurrentCulture.NumberFormat);
            return "" + Campo;
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

        public object Clone()
        {
            //Shallow copy dei riferimenti
            Statistica newStatistica = (Statistica)this.MemberwiseClone();

            //Deep copy del dizionario
            newStatistica.Campi = CampiClone();

            return newStatistica;
        }

        //Deep copy del dizionario
        private Dictionary<string, CampoStatistica> CampiClone()
        {
            Dictionary<string, CampoStatistica> newDict = new Dictionary<string, CampoStatistica>();
            foreach (KeyValuePair<string, CampoStatistica> item in this.Campi)
            {
                newDict.Add(item.Key, new CampoStatistica(item.Value.Campo));
            }
            return newDict;
        }

        #endregion

    }

    class StatisticaSquadra : Statistica
    {

        private readonly Squadra _squadra;
        
        public StatisticaSquadra(Squadra squadra, int punti, int partiteGiocate, int partiteVinte, int partitePerse)
        {            
            if (squadra == null)
                throw new ArgumentException("squadra == null");
            if (punti < 0)
                throw new ArgumentException("punti < 0 ");
            if (partiteGiocate < 0)
                throw new ArgumentException("partiteGiocate < 0");
            if (partiteVinte < 0)
                throw new ArgumentException("partiteVinte < 0");
            if (partitePerse < 0)
                throw new ArgumentException("partitePerse < 0");

            _squadra = squadra;

            SetCampo("Punti", new CampoStatistica(punti));
            SetCampo("Partite Giocate", new CampoStatistica(partiteGiocate));
            SetCampo("Partite Vinte", new CampoStatistica(partiteVinte));
            SetCampo("Partite Perse", new CampoStatistica(partitePerse));
            
        }

        public Squadra Squadra 
        {
            get { return _squadra; }
        }

        public override string ToString()
        {
            return Squadra.Nome;
        }

    }

    class StatisticaGiocatore : Statistica
    {

        private readonly Partita _partita;
        private readonly Giocatore _giocatore;

        public StatisticaGiocatore(Partita partita, Giocatore giocatore, int punti, int tent2segn, int tent2tot, int tent3segn, int tent3tot, int tlSegn, int tlTot, int palleRec, int minGiocati)
        {            
            if (partita == null)
                throw new ArgumentException("partita == null");
            if (giocatore == null)
                throw new ArgumentException("giocatore == null");
            if (punti < 0)
                throw new ArgumentException("punti < 0 ");
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

            SetCampo("Punti", new CampoStatistica(punti));
            SetCampo("Tentativi Da 2 Segnati", new CampoStatistica(tent2segn));
            SetCampo("Tentativi Da 2 Totali", new CampoStatistica(tent2tot));
            SetCampo("Tentativi Da 3 Segnati", new CampoStatistica(tent3segn));
            SetCampo("Tentativi Da 3 Totali", new CampoStatistica(tent3tot));
            SetCampo("Tiri Liberi Segnati", new CampoStatistica(tlSegn));
            SetCampo("Tiri Liberi Totali", new CampoStatistica(tlTot));
            SetCampo("Palle Recuperate", new CampoStatistica(palleRec));
            SetCampo("Minuti Giocati", new CampoStatistica(minGiocati));

        }

        public Partita Partita
        {
            get { return _partita; }
        }

        public Giocatore Giocatore
        {
            get { return _giocatore; }
        }

        //Va aggiunto quello di squadra, oppure mettere questo nella classe madre

        public override String ToString()
        {
            //return Giocatore + " " + Partita;
            return Giocatore.ToString();
        }

    }
}
