using System;

namespace IronNinja
{
    class SweetTooth : Ninja
    {
        public override bool IsFull
        {
            get
            {
                if (calorieIntake > 1500)
                {
                    Console.WriteLine("SweetTooth is full and cannot eat anymore. Total calories: " + calorieIntake);
                    return true;
                } else
                {
                    return false;
                }
            }
        }

        // public SweetTooth()
        // {
        //     Console.WriteLine("Constructor SweetTooth"); 
        // }
        public override void Consume(IConsumable item)
        {
            item.GetInfo();
            if (!IsFull)
            {
                calorieIntake += item.Calories;
                if (item.IsSweet)
                {
                    calorieIntake += 10;
                }
                // Console.WriteLine("SweetTooth consuming " +  item.Name + "  Calories: " +  item.Calories + " Intake = " + calorieIntake);
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
        }
    }
}