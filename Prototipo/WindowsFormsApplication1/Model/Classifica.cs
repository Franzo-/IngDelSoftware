using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    class Classifica
    {
        private IEnumerable<Statistica> _statistiche;
        private ISelezionatore _selezionatore;
        private ICalcoloVisitor _visitor;

        private static Classifica _instance;

        public event EventHandler Changed;

        private Classifica()
        {

        }

        public static Classifica GetInstance()
        {
            if (_instance == null)
                _instance = new Classifica();
            return _instance;
        }

        public ISelezionatore Selezionatore
        {
            get { return _selezionatore; }
            set
            {
                if (value != null && value != _selezionatore)
                {
                    _selezionatore = value;
                    Invalidate();
                }
            }
        }

        public ICalcoloVisitor Visitor
        {
            get 
            {
                if (_visitor == null)
                    _visitor = new CalcoloVisitor();
                return _visitor; 
            }
            set { _visitor = value; }
        }

        public IEnumerable<Statistica> GetStatistiche() 
        {
            if (_statistiche == null)
            {
                _statistiche = _selezionatore.GetStatistiche();
            }
            return _statistiche;
        }

        public void EseguiCalcolo(string nomeMetodo)
        {
            foreach (Statistica statistica in GetStatistiche())
            {
                statistica.Accept(Visitor, nomeMetodo);
            }

            // La view deve essere avvisata del calcolo effettuato per includere il nuovo campo
            OnChanged();
        }

        public void Invalidate()
        {
            _statistiche = null;
            OnChanged();
        }

        private void OnChanged()
        {
            if (Changed != null)
                Changed(this, EventArgs.Empty);
        }
    }
}
