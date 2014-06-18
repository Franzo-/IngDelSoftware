using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    abstract class SelezionatoreStatGiocatore : ISelezionatore
    {
        private readonly SelezionatoreStatGiocatore _selezionatore;

        public readonly static SelezionatoreStatGiocatore SelezionatoreTutteStatGiocatori;  //TODO

        protected SelezionatoreStatGiocatore(SelezionatoreStatGiocatore selezionatore)
        {
            _selezionatore = selezionatore ?? SelezionatoreTutteStatGiocatori;
        }

        public IEnumerable<Statistica> GetStatistiche()
        {
            return GetStatisticheGiocatore();
        }

        protected virtual IEnumerable<StatisticaGiocatore> GetStatisticheGiocatore()
        {
            return _selezionatore.GetStatisticheGiocatore().Where(Predicate);
        }

        //Predicato di default che non filtra nulla; virtual perché può non essere ridefinito
        protected virtual Func<StatisticaGiocatore, bool> Predicate 
        {
            get { return statistica => true; } 
        }

        private class _SelezionatoreTutteStatGiocatori : SelezionatoreStatGiocatore
        {

            public _SelezionatoreTutteStatGiocatori()
            {
                _selezionatore = null;
            }

            protected override IEnumerable<StatisticaGiocatore> GetStatisticheGiocatore()
            {
                return base.GetStatisticheGiocatore();
            }
            
        }
    }
}
