using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    abstract class SelezionatoreStatGiocBase : ISelezionatore
    {

        public IEnumerable<Statistica> GetStatistiche()
        {

            return Normalize( GetStatisticheGiocatore() );
        }

        private IEnumerable<StatisticaGiocatore> Normalize(IEnumerable<StatisticaGiocatore> stats)
        {
            Dictionary<Giocatore, StatisticaGiocatore> dizionario = new Dictionary<Giocatore, StatisticaGiocatore>();

            //Variabili d'appoggio
            StatisticaGiocatore statistica = null;


            foreach (StatisticaGiocatore stat in stats)
            {
                //Se c'è già
                if (dizionario.Keys.Contains<Giocatore>(stat.Giocatore))
                {
                    statistica = dizionario[stat.Giocatore];

                    foreach (String nomeCampo in statistica.GetNomiCampi())
                    {
                        statistica.SetCampo(nomeCampo, statistica.GetCampo(nomeCampo) + stat.GetCampo(nomeCampo));
                    }
                    dizionario[statistica.Giocatore] = statistica;

                }


                //Se non c'è ancora
                else
                {
                    dizionario.Add(stat.Giocatore, stat);
                }

            }

            return dizionario.Values;
        }

        public abstract IEnumerable<StatisticaGiocatore> GetStatisticheGiocatore();
    }

    abstract class SelezionatoreStatGiocatore : SelezionatoreStatGiocBase
    {
        private readonly SelezionatoreStatGiocBase _selezionatore;

        protected SelezionatoreStatGiocatore(SelezionatoreStatGiocBase selezionatore)
        {
            if (selezionatore == null)
                throw new ArgumentException("selezionatore == null!");

            _selezionatore = selezionatore;
        }


        protected IEnumerable<StatisticaGiocatore> GetStatisticheGiocatore()
        {
            return _selezionatore.GetStatisticheGiocatore().Where(Predicate);
        }

        protected abstract Func<StatisticaGiocatore, bool> Predicate { get; }

    }

    class SelezionatoreTutteStatGiocatori : SelezionatoreStatGiocBase
    {

        protected override IEnumerable<StatisticaGiocatore> GetStatisticheGiocatore()
        {
            //TODO: espressione LINQ?
            return /* GetCurrentCampionato.GetStatistiche */;
        }

    }

    class SelezionatoreStatGiocatorePerPartita : SelezionatoreStatGiocatore
    {
        private readonly Partita _partita;

        public SelezionatoreStatGiocatorePerPartita(SelezionatoreStatGiocBase selezionatore, Partita partita) : base(selezionatore)
        {
            if (partita == null)
                throw new ArgumentException("partita == null");
            _partita = partita;
        }

        protected override Func<StatisticaGiocatore, bool> Predicate
        {
            get { return statistica => statistica.Partita == _partita; }
        }
    }

    class SelezionatoreStatGiocatorePerSquadra : SelezionatoreStatGiocatore
    {
        private readonly Squadra _squadra;

        public SelezionatoreStatGiocatorePerSquadra(SelezionatoreStatGiocBase selezionatore, Squadra squadra) : base(selezionatore)
        {
              if (squadra == null)
                  throw new ArgumentException("squadra == null");

              _squadra = squadra;
        }

        protected override Func<StatisticaGiocatore, bool> Predicate
        {
            //TODO
            get { return statistica => _squadra.GetRooster(/* GetCurrentCampionato.Anno */).Contains(statistica.Giocatore); }
        }
    }
}
