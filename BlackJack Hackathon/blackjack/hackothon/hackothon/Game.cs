using System;
using System.Collections.Generic;
namespace hackothon 
{

    class Game 
    {
        // public bool gameState;
        public string Name {get; set;}
        public List<Card> hand;
        public bool IsStanding {get; set;}
        public int TotalHandVal {get; set;}
        public bool Win {get; set;}


        public Game()
        {
            hand = new List<Card>();
            IsStanding = false;
            TotalHandVal = 0;
        }


        public void Draw(Deck deck)
        {
            if (!IsStanding) 
            {
                Card drawnCard = deck.Deal();
                // add this card to player's Hand
                hand.Add(drawnCard);
                // Console.WriteLine("Draw card = " + drawnCard.StringVal + "  " + drawnCard.Suit + "  " + drawnCard.Val);
                // int TotalHandVal = 0;
                foreach (Card crd in hand)
                {
                    if (crd.StringVal == "Jack" || crd.StringVal == "Queen" || crd.StringVal == "King")
                    {
                        TotalHandVal += 10;
                    }
                    else 
                    {
                        TotalHandVal += crd.Val;
                    }
                }
                // if (TotalHandVal > 21)
                // {
                //     Win = false;
                // }
            }
        }
        
    }

}