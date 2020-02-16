using System;
using System.Collections.Generic;


namespace HungryNinja
{

    class Food
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public bool isSpicy { get; set; }
        public bool isSweet { get; set; }

        public Food(string n, int cal, bool spice, bool sweet)
        {
            Name = n;
            Calories = cal;
            isSpicy = spice;
            isSweet = sweet;
        }
    }

    class Buffet
    {
        public List<Food> Menu;
        public Buffet()
        {
            Menu = new List<Food>() {new Food("Chicken", 1000, true, false)};
            Menu.Add(new Food("Salad", 150, true, false));
            Menu.Add(new Food("Pizza", 300, true, false));
            Menu.Add(new Food("Tiramisu", 200, false, true));
            Menu.Add(new Food("Ice Cream", 100, false, true));
            Menu.Add(new Food("Pasta", 250, true, false));
            Menu.Add(new Food("Club Sandwich", 130, true, false));

            for (int i = 0; i < Menu.Count; i++) {
                Console.WriteLine("Food: " + Menu[i].Name + ", " + Menu[i].Calories);
            }
        }

        public Food Serve()
        {
            Random rand = new Random();
            int menuIndex = rand.Next(Menu.Count);
            Food food = Menu[menuIndex];
            return food;
        }
    }

    class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;
        public bool isFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    Console.WriteLine("Ninja is Full now, cannot eat anymore");
                    return true;
                } else
                {
                    return false;
                }
            }
        }
        public Ninja()
        {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        public void Eat(Food item)
        {
            if (!isFull)
            {
                calorieIntake += item.Calories;
                FoodHistory.Add(item);
                string spicyness = item.isSpicy ? "Spicy" : "Sweet";
                Console.WriteLine("Ate food " + item.Name + " and its " + spicyness + "  Calories: " + calorieIntake);
            }
;        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            Ninja ninja = new Ninja();
            while (!ninja.isFull)
            {
                Food food = buffet.Serve();
                ninja.Eat(food);
            }
            
        }
    }
}
