using System;
using System.Collections.Generic;


namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>() {new Food("Chicken", 400, true, false)};
            Menu.Add(new Food("Salad", 150, true, false));
            Menu.Add(new Food("Pizza", 300, true, false));
            Menu.Add(new Food("Tiramisu", 200, false, true));
            Menu.Add(new Food("Ice Cream", 100, false, true));
            Menu.Add(new Food("Pasta", 250, true, false));
            Menu.Add(new Food("Club Sandwich", 130, true, false));
            Menu.Add(new Drink("Coke", 280));
            Menu.Add(new Drink("Sprite", 250));
            Menu.Add(new Drink("Pepsi", 250));

            // for (int i = 0; i < Menu.Count; i++) {
            //     Console.WriteLine("Food: " + Menu[i].Name + ", " + Menu[i].Calories);
            // }
        }

        public IConsumable Serve()
        {
            Random rand = new Random();
            int menuIndex = rand.Next(Menu.Count);
            IConsumable consumable = Menu[menuIndex];
            System.Console.WriteLine("Served " + consumable.Name + ", Calories " + consumable.Calories);
            return consumable;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            SweetTooth swTooth = new SweetTooth();
            SpiceHound spHound = new SpiceHound();
            while (!swTooth.IsFull)
            {
                IConsumable swConsumable = buffet.Serve();
                swTooth.Consume(swConsumable);
            }
            Console.WriteLine($"SweetToooth consumed {swTooth.ConsumptionHistory.Count} items");
            while (!spHound.IsFull)
            {
                IConsumable spConsumable = buffet.Serve();
                spHound.Consume(spConsumable);
            }
            Console.WriteLine($"SpiceHound consumed {spHound.ConsumptionHistory.Count} items");
        }
    }
}
