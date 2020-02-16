using System;

namespace WizardNinjaSamurai
{
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public Human(string name, int strength, int intel, int dex, int hp)
        {
            Name = name;
            Strength = strength;
            Intelligence = intel;
            Dexterity = dex;
            health = hp;
        }

        public virtual int Attack(Human target)
        {
            int dmg = 3*Strength;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }

    class Wizard :  Human
    {
        public Wizard(string name, int strength, int dex)  : base(name, strength, 25, dex, 50)
        {

        }

        public override int Attack(Human target)
        {
            int dmg = 5*Intelligence;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {Name} for {dmg} damage!");
            return target.Health;
        }

        public void Heal(Human target)
        {
            target.Health += Intelligence*10;
            Console.WriteLine($"{target.Name} healed to {target.Health}");
        }
           
    }

    class Ninja : Human
    {
        public Ninja(string name, int strength, int intel, int hp)  : base(name, strength, intel, 175, hp)
        {

        }
        public override int Attack(Human target)
        {
            int dmg = 5*Dexterity;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {Name} for {dmg} damage!");
            return target.Health;
        }

        public void Steal(Human target)
        {
            target.Health -= 5;
            Health += target.Health;
            Console.WriteLine($"{Name} stole {Health} points from {target.Name}!");

        }
    }

    class Samurai  : Human
    {
        public Samurai (string name, int strength, int intel, int dex)  : base(name, strength, intel, dex, 200)
        {

        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if (target.Health < 50)
            {
                target.Health = 0;
            }
            Console.WriteLine($"{Name} health less that 50 points !");
            return target.Health;
        }
        public void Meditate(int hp)
        {
            Health = hp;
            Console.WriteLine($"Healed {Name} to full health");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Wizard jack = new Wizard("Jack", 3, 3);
            Ninja tom = new Ninja("Tom", 3, 3, 100);
            Samurai ben = new Samurai("Ben", 3, 3, 3);
            jack.Health = 4;
            int jackHealth = jack.Attack(tom);
            Console.WriteLine("jackHealth  = " + jackHealth);
            int samuariHealth = tom.Attack(ben);
            Console.WriteLine("samuariHealth  = " + samuariHealth);
            jack.Heal(tom);
            ben.Meditate(100);
            tom.Steal(jack);
        }
    }
}
