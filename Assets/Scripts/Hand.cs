﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public Card[] cards;

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

    // Use this for initialization
    void Awake () {
        graveyard = GetComponent<Graveyard>();
        deck = GetComponent<Deck>();
    }

    void Start()
    {
        cards = new Card[GameSettings.maxHandCardCount];
    }

    public void PlaySelectedCard(Vector2 position)
    {
        if (!PlayArea.Instance.Contains(position))
            return;

        Card playCard = cards[selectedCardId];

        //Remove the card from the hand
        cards[selectedCardId] = null;

        //play the card
        Board.Instance.PlayCard(playCard, position);

        //Add the card to the graveyard
        graveyard.Add(playCard);
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
    }
}
