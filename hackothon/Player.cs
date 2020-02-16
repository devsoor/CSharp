using System;
using System.Collections.Generic;
namespace hackothon 
{
class Player : Game
    {
        
        public int Chips {get; set;}
        public int ChipsBet {get; set;}

        public Player(string name) 
        {
            Name = name;
            Chips = 10;
            ChipsBet = 0;
        }

        public Card Discard(int i)
        {
            if (i < 0 || i >= hand.Count)
            {
                return null;
            } else {
                Card crd = hand[i];
                Console.WriteLine("Disarding card = " + crd.StringVal + "  " + crd.Suit + "  " + crd.Val);
                hand.RemoveAt(i);
                return crd;
            }
        }

        public void DisplayPlayerHand()
        {
            foreach (Card c in hand)
            {
                Console.WriteLine("Player hand: " + c.StringVal + " of " + c.Suit);
            }
        }
    }
}
    