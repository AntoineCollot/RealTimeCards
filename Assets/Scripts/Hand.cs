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

    //[HideInInspector]
    public int selectedCardId = -1;

    [HideInInspector]
    public Graveyard graveyard;

    Deck deck;
    [HideInInspector]
    public PlayerPlayArea localPlayArea;

    Animator anim;

    // Use this for initialization
    void Awake () {
        graveyard = GetComponent<Graveyard>();
        deck = GetComponent<Deck>();
        localPlayArea = GetComponent<PlayerPlayArea>();
        anim = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        cards = new Card[GameSettings.maxHandCardCount];
        UpdateCardDisplay();
    }

    void Update()
    {
        for(int i=0;i<cardDisplays.Length;i++)
        {
            if (i == selectedCardId)
                cardDisplays[i].transform.localScale = Vector3.one * 1.2f;
            else
                cardDisplays[i].transform.localScale = Vector3.one;
        }
    }

    public void PlaySelectedCard(Vector2 position,Color color = default(Color))
    {
        if (selectedCardId < 0)
            return;
        PlayCard(selectedCardId, position,color);
        selectedCardId = -1;
    }

    public void PlayCard(int id,Vector2 position, Color color = default(Color))
    {
        if (!CanPlayCardThere(id,position))
            return;

        Card playCard = cards[id];

        //Remove the card from the hand
        cards[id] = null;

        //play the card
        Board.Instance.PlayCard(playCard, position,gameObject,color);

        //Add the card to the graveyard
        graveyard.Add(playCard);

        UpdateCardDisplay();

        if(anim!=null)
            anim.SetTrigger("Cast");
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
        if (selectedCardId < 0)
            return false;
        return CanPlayCardThere(selectedCardId, position);
    }

    public bool CanPlayCardThere(int id,Vector2 position)
    {
        if (cards[id] == null)
            return false;
        if (cards[id].type == Card.Type.Monster)
            return localPlayArea.Contains(position);
        else
            return PlayArea.Instance.Contains(position);
    }

    public Card GetRandomCard()
    {
        List<Card> availableCards = new List<Card>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null)
                availableCards.Add(cards[i]);
        }

        if (availableCards.Count == 0)
            return null;
        else
            return availableCards[Random.Range(0, availableCards.Count)];
    }

    public int GetRandomCardId()
    {
        List<int> availableCardsId = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i] != null)
                availableCardsId.Add(i);
        }

        if (availableCardsId.Count == 0)
            return -1;
        else
            return availableCardsId[Random.Range(0, availableCardsId.Count)];
    }
}
