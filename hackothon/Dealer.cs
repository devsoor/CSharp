using System;
using System.Collections.Generic;

namespace hackothon
{
    class Dealer : Game
    {
        public Dealer() 
            {
                Name = "Bob";
            }
        public void DisplayDealerHand()
        {
            Console.WriteLine(hand[0].StringVal + " of " + hand[0].Suit);
        }
        
        public void DrawCards(Deck deck)
        {
           
            while (TotalHandVal < 17)
            {
                
                Draw(deck);
            }
        }

    }

}