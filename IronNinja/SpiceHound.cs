using System;
using System.Collections.Generic;

namespace IronNinja
{
    class SpiceHound : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake > 1200)
                {
                    Console.WriteLine("SpiceHound is full and cannot eat anymore. Total calories: " + calorieIntake);
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        // public SpiceHound() : base()
        // {
        //     Console.WriteLine("Constructor SpiceHound"); 
        // }

        public override void Consume(IConsumable item)
        {
            if (!IsFull)
            {
                calorieIntake += item.Calories;
                if (item.IsSpicy)
                {
                    calorieIntake -= 5;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
            item.GetInfo();

        }
    }
}