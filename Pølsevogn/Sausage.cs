using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public enum SausageType
    {
        None, Grilled, Boiled
    }
    public class Sausage : Food, IBoilFood, IRoastFood
    {
        private SausageType type;
        public Sausage(string name, SausageType type) : base(name)
        {
            this.type = type;
            SetSausageType();
        }

        public void Roast()
        {
            Prepare(1);
        }
        public void Cook()
        {
            Prepare(1);
        }

        private void SetSausageType()
        {
            if (type == SausageType.Grilled)
                Roast();
            else if (type == SausageType.Boiled)
                Cook();
        }

        private void Prepare(int time)
        {
            Thread.Sleep(time);
            IsDone = true;
        }

    }
}
