using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    [SerializeField]
    DeckCard[] cardsInDeck;

    List<Card> cards;

    public Card Draw()
    {
        if (cards.Count <= 0)
            return null;

        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
    }

    void Start()
    {
        cards = new List<Card>();

        foreach(DeckCard c in cardsInDeck)
        {
            for (int i = 0; i < c.count; i++)
            {
                cards.Add(c.card);
            }
        }

        Shuffle();
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Card shuffledCard = cards[i];
            int randomId = Random.Range(0, cards.Count);
            cards[i] = cards[randomId];
            cards[randomId] = shuffledCard;
        }
    }

    [System.Serializable]
    public struct DeckCard
    {
        public Card card;
        public int count;
    }
}
