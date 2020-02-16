using System;
using System.Collections.Generic;
namespace hackothon 
{
   class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            MakeDeck();
        }

        public void MakeDeck()
        {
            string[] suitNames = {"Clubs", "Spades", "Hearts", "Diamonds"};
            Dictionary<int, string> pictureCards = new Dictionary<int, string>()
            {
                {1, "Ace"},
                {11, "Jack"},
                {12, "Queen"},
                {13, "King"}
            };

            for (int i = 1; i <= 13; i++)
            {
                foreach (string name in suitNames)
                {
                    if (i == 1 || i == 11 || i == 12 || i == 13)
                    {
                        cards.Add(new Card(pictureCards[i], name, i));
                    } else {
                        cards.Add(new Card(i.ToString(), name, i));
                    }
                    // Console.WriteLine("card name = " + name);
                }
            }
        }

        public void DisplayDeck()
        {
            foreach (Card c in cards)
            {
                Console.WriteLine("Deck card: " + c.StringVal + "   " + c.Suit);
            }
        }
        public Card Deal()
        {
            // get the top most card which is first one in cards List
            Card topCard = cards[0];
            cards.RemoveAt(0);
            return topCard;
        }

        public void Reset()
        {
            cards.Clear();
            MakeDeck();
        }

        public void Shuffle()
        {
            Random rand = new Random();
            int totalItems = cards.Count;
            while (totalItems > 1)
            {
                // get a random index and replace it with last element
                totalItems--;
                int randIndex = rand.Next(totalItems);
                Card value = cards[randIndex];
                cards[randIndex] = cards[totalItems];
                cards[totalItems] = value;
            }
        }
    }
}
