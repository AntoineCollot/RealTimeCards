using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    public List<Card> cards = new List<Card>();

    public Card selectedCard;

    [HideInInspector]
    public Graveyard graveyard;

    // Use this for initialization
    void Awake () {
        graveyard = GetComponent<Graveyard>();
    }

    public void PlaySelectedCard(Vector2 position)
    {
        if (!PlayArea.Instance.Contains(position))
            return;

        //Remove the card from the hand
        cards.Remove(selectedCard);

        //play the card
        Board.Instance.PlayCard(selectedCard,position);

        //Add the card to the graveyard
        graveyard.Add(selectedCard);
        selectedCard = null;
    }

}
