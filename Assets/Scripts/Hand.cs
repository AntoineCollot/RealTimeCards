using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public Card[] cards;
    public CardDisplay[] cardDisplays;

    public int cardCount
    {
        get
        {
            int count = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] != null)
                    count++;
            }

            return count;
        }
    }

    public int selectedCardId;

    [HideInInspector]
    public Graveyard graveyard;

    Deck deck;
    PlayerPlayArea localPlayArea;

    // Use this for initialization
    void Awake () {
        graveyard = GetComponent<Graveyard>();
        deck = GetComponent<Deck>();
        localPlayArea = GetComponent<PlayerPlayArea>();
    }

    void Start()
    {
        cards = new Card[GameSettings.maxHandCardCount];
        UpdateCardDisplay();
    }

    public void PlaySelectedCard(Vector2 position)
    {
        if (!CanPlaySelectedCardThere(position))
            return;

        Card playCard = cards[selectedCardId];

        //Remove the card from the hand
        cards[selectedCardId] = null;

        //play the card
        Board.Instance.PlayCard(playCard, position);

        //Add the card to the graveyard
        graveyard.Add(playCard);

        UpdateCardDisplay();
    }

    public void DrawFromDeck()
    {
        //Find a spot
        for (int i = 0; i < cards.Length; i++)
        {
            if(cards[i]==null)
            {
                cards[i] = deck.Draw();
                break;
            }
        }

        UpdateCardDisplay();
    }

    void UpdateCardDisplay()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cardDisplays[i].card = cards[i];
        }
    }

    public bool CanPlaySelectedCardThere(Vector2 position)
    {
        if (cards[selectedCardId] == null)
            return false;
        if (cards[selectedCardId].type == Card.Type.Monster)
            return localPlayArea.Contains(position);
        else
            return PlayArea.Instance.Contains(position);
    }
}
