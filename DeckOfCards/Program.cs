using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Card
    {
        public string StringVal  { get; set; }
        public string Suit  { get; set; }
        public int Val  { get; set; }
    
        public Card(string stringVal, string suit, int val)
        {
            StringVal = stringVal;
            Suit = suit;
            Val = val;
        }

    }
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

    class Player
    {
        public string Name {get; set;}
        public List<Card> hand;

        public Player()
        {
            hand = new List<Card>();
        }

        public Card Draw(Deck deck)
        {
            Card drawnCard = deck.Deal();
            // add this card to player's Hand
            hand.Add(drawnCard);
            Console.WriteLine("Draw card = " + drawnCard.StringVal + "  " + drawnCard.Suit + "  " + drawnCard.Val);
            return drawnCard;
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
                Console.WriteLine("Player hand: " + c.StringVal + "   " + c.Suit);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.DisplayDeck();
            Card card = deck.Deal();
            Console.WriteLine("Dealt card = " + card.StringVal + "  " + card.Suit + "  " + card.Val);
            // Console.WriteLine("Resetting deck");
            // for (int x = 0; x < 30; x++)
            // {
            //     Card c = deck.Deal();
            //     Console.WriteLine("Dealt card = " + card.StringVal + "  " + card.Suit + "  " + card.Val);
            // }
            deck.DisplayDeck();

            // deck.Reset();
            // deck.DisplayDeck();
            // Console.WriteLine("Shuffling deck");
            deck.Shuffle();
            deck.DisplayDeck();
            Player player = new Player();
            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.Draw(deck);
            player.DisplayPlayerHand();
            player.Discard(2);
            player.DisplayPlayerHand();
        }
    }
}
