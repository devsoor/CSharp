using System;

namespace Human
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;
        public Human(string n)
        {
            Name = n;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;

        }

        public Human(string name, int strength, int intel, int dex, int hlth)
        {
            Name = name;
            Strength = strength;
            Intelligence = intel;
            Dexterity = dex;
            health = hlth;
        }

        public int Attack(Human target)
        {
            target.health -= 5*this.Strength;
            return target.health;
        }
        public int HealthProp
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Human jack = new Human("Jack");
            Human tom = new Human("Tom");
            jack.HealthProp = 4;
            int jackHealth = jack.Attack(tom);
            Console.WriteLine("jackHealth  = " + jackHealth);
        }
    };

 
}
