using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player {

    Camera cam;

	// Use this for initialization
	protected override void Awake () {
        base.Awake();

        cam = Camera.main;
	}

    // Update is called once per frame
    void Update()
    {
        //Look for player's input for each card in hand
        for (int i = 0; i < hand.cards.Count; i++)
        {
            ProcessCardInput(i);
        }
    }

    void ProcessCardInput(int id)
    {
        //Do nothing if the id is greater than the number of card we have
        if (id >= hand.cards.Count)
            return;

        if (Input.GetButtonDown("PlayCard" + id))
        {
            hand.selectedCard = hand.cards[id];
        }
        if (Input.GetButtonUp("PlayCard" + id))
        {
            if (hand.selectedCard == hand.cards[id])
            {
                hand.PlaySelectedCard(GetPlayPosition());
            }
        }
    }

    Vector2 GetPlayPosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
