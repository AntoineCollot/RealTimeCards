using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graveyard : MonoBehaviour {

    List<Card> destroyedCards = new List<Card>();
	
	public void Add(Card card)
    {
        destroyedCards.Add(card);
    }
}
