using System;

namespace Pølsevogn
{
    class Program
    {
        
        static void Main(string[] args)
        {
            SausageCart cart = new SausageCart();
            cart.TakeOrder(new Hotdog("Hotdog", cart.Grill.Sausages[0], cart.Dressings));
            cart.TakeOrder(new Hotdog("Hotdog", cart.Grill.Sausages[0], cart.Dressings));
            cart.GetOrders();
            Console.WriteLine(cart.eventMessage);
            Console.Read();

        }
    }
}