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

                if (drawnCard.StringVal == "Jack" || drawnCard.StringVal == "Queen" || drawnCard.StringVal == "King")
                {
                    TotalHandVal += 10;
                }
                else
                {
                    TotalHandVal += drawnCard.Val;
                }
            }
        }
        
    }

}