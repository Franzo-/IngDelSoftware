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

        public event EventHandler Changed;

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

        public IEnumerable<Statistica> GetStatistiche() 
        {
            if (_statistiche == null)
            {
                _statistiche = _selezionatore.GetStatistiche();
            }
            return _statistiche;
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
