using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketSystem.Model
{
    interface ICalcoloVisitor
    {
        void Visit(Statistica statistica, string metodo);
    }
}
