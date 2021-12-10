using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public class Grill : IContainSausage
    {
        public Sausage[] Sausages { get; set; }

        public Grill(int space)
        {
            Sausages = new Sausage[space];
        }

    }
}
