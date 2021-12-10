using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public abstract class Dressing
    {
        public EventHandler OnDressingEmpty;
        public string Name { get; set; }
        public int MaxServings { get; set; } = 30;
        public int ServingsLeft { get; set; }

        public Dressing(string name)
        {
            Name = name;
            ServingsLeft = MaxServings;
        }

        public void Use()
        {
            if (ServingsLeft > 0)
                ServingsLeft--;

            CheckIfEmpty();
        }

        private void CheckIfEmpty()
        {
            if (ServingsLeft <= 0)
                OnOrderReadyTrigger($"{Name} is empty! change the flask");
        }

        private void OnOrderReadyTrigger(string message)
        {
            EventHandler handler = OnDressingEmpty;
            if (handler != null)
            {
                OnDressingEmpty(message, EventArgs.Empty);
            }
        }
    }
}
