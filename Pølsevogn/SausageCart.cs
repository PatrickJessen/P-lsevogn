using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pølsevogn
{
    public class SausageCart
    {
        public IContainSausage Pot { get; set; }
        public IContainSausage Grill { get; set; }
        public Dressing[] Dressings { get; set; }
        public Order[] Orders { get; set; }

        public string eventMessage;

        public SausageCart()
        {
            Pot = new Pot(20);
            Grill = new Grill(30);
            Dressings = new Dressing[2];
            Orders = new Order[3];
            InitDressing();
            AddSausageToGrill(10);
            AddSausageToPot(10);
        }

        public void TakeOrder(Food food)
        {
            for (int i = 0; i < Orders.Length; i++)
                if (Orders[i] == null)
                {
                    Orders[i] = new Order(i, food);
                    Orders[i].OnOrderReady += Order_OnMessageReceived;
                    return;
                }
        }

        public void GetOrders()
        {
            eventMessage = "";
            for (int i = 0; i < Orders.Length; i++)
            {
                if (Orders[i] != null)
                    eventMessage += Orders[i].Food.Name + "\n";
            }
        }

        public void ChangeDressing(Dressing dressing)
        {
            for (int i = 0; i < Dressings.Length; i++)
                if (Dressings[i] != null || Dressings[i].ServingsLeft <= 0)
                {
                    Dressings[i] = dressing;
                    dressing.OnDressingEmpty += Dressing_OnDressingEmpty;
                    return;
                }
        }

        public Sausage GetGrilledSausage()
        {
            for (int i = 0; i < Grill.Sausages.Length; i++)
                if (Grill.Sausages[i].IsDone)
                    return Grill.Sausages[i];
            return null;
        }

        public void AddSausageToGrill(int amount)
        {
            AddSausage(amount, SausageType.Grilled, Grill);
        }

        public void AddSausageToPot(int amount)
        {
            AddSausage(amount, SausageType.Boiled, Pot);
        }

        private void AddSausage(int amount, SausageType type, IContainSausage cookType)
        {
            for (int i = 0; i < amount; i++)
                if (cookType.Sausages[i] == null)
                    cookType.Sausages[i] = new Sausage("Sausage", type);
        }

        private void InitDressing()
        {
            Dressings[0] = new Ketchup("Ketchup");
            Dressings[0].OnDressingEmpty += Dressing_OnDressingEmpty;
            Dressings[1] = new Ketchup("Mustard");
            Dressings[1].OnDressingEmpty += Dressing_OnDressingEmpty;
        }

        private void Dressing_OnDressingEmpty(object sender, EventArgs e)
        {
            eventMessage = sender.ToString();
        }

        private void Order_OnMessageReceived(object sender, EventArgs e)
        {
            eventMessage = sender.ToString();
        }

    }
}
