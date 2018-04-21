using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {

    [HideInInspector]
    public List<Card> cards = new List<Card>();

    [HideInInspector]
    public Card selectedCard;

    // Use this for initialization
    void Start () {
		
	}



    public void PlaySelectedCard(Vector2 position)
    {
        selectedCard.Play(position);
        selectedCard = null;
    }
}
