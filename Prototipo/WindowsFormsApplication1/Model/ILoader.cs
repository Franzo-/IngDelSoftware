using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    interface ILoader
    {
        //Metodi per il caricamento da xml
        /*ICollection<Giocatore> LoadGiocatori();
        ICollection<Squadra> LoadSquadre();
        Dictionary<int, HashSet<Giocatore>> LoadRoster();
        ICollection<Campionato> LoadCampionato();*/

        void Load();

    }
}
