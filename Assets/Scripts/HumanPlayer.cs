using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanPlayer : Player {

    Camera cam;

    PointerOverlay pointerOverlay;

	// Use this for initialization
	protected override void Awake () {
        base.Awake();

        cam = Camera.main;
        pointerOverlay = GetComponentInChildren<PointerOverlay>();
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

        if (Input.GetButtonDown("PlayCard" + (id+1)))
        {
            hand.selectedCard = hand.cards[id];

            //pointerOverlay.SetOverlay(hand.selectedCard.GetOverlay());
        }
        if (Input.GetButtonUp("PlayCard" + (id+1)))
        {
            if (hand.selectedCard == hand.cards[id])
            {
                hand.PlaySelectedCard(GetPlayPosition());
                pointerOverlay.ClearOverlay();
            }
        }
    }

    public Vector2 GetPlayPosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
