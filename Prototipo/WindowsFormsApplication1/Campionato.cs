using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Campionato
    {
        private readonly int _anno;
        private readonly IEnumerable<Squadra> _squadre;
        private readonly IEnumerable<Partita> _calendario;
        private readonly Serie _serie;
    }
}
