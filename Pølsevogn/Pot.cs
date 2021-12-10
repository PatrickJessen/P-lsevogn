using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public class Pot : IContainSausage
    {
        public Sausage[] Sausages { get; set; }

        public Pot(int space)
        {
            Sausages = new Sausage[space];
        }
    }
}
