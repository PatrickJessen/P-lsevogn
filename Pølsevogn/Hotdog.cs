using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public class Hotdog : Food, IAddExtra
    {
        public Sausage Sausage { get; set; }
        public Dressing[] Dressings { get; set; }
        public Hotdog(string name, Sausage sausage, Dressing[] dressings) : base(name)
        {
            Sausage = sausage;
            IsDone = Sausage.IsDone;
            Dressings = dressings;
            AddExtra();
        }

        public void AddExtra()
        {
            for (int i = 0; i < Dressings.Length; i++)
                if (Dressings[i] != null)
                    Dressings[i].Use();
        }
    }
}
