using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour {

    public List<Card> cards = new List<Card>();

    public Card Draw()
    {
        Card topCard = cards[0];
        cards.RemoveAt(0);
        return topCard;
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
}
