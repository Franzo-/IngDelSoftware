using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    interface ISelezionatore
    {
        IEnumerable<Statistica> GetStatistiche();
    }
}
