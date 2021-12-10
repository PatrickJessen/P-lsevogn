using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public class Order
    {
        public EventHandler OnOrderReady;
        public int Id { get; set; }
        public decimal Price { get; set; }
        public Food Food { get; set; }

        public Order(int id, Food food)
        {
            Id = id;
            Food = food;
        }

        public string PlaceOrder()
        {
            return "";
        }

        public void Serve()
        {
            if (Food.IsDone)
                OnOrderReadyTrigger($"Order id: {Id} is ready! {Food.Name}");
            Food.IsDone = false;
        }

        private void OnOrderReadyTrigger(string message)
        {
            EventHandler handler = OnOrderReady;
            if (handler != null)
            {
                OnOrderReady(message, EventArgs.Empty);
            }
        }
    }
}
