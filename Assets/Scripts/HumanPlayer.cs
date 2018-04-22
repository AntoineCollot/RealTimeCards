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
        for (int i = 0; i <GameSettings.maxHandCardCount; i++)
        {
            ProcessCardInput(i);
        }

        pointerOverlay.authorizedPlay = hand.CanPlaySelectedCardThere(GetPlayPosition());
    }

    void ProcessCardInput(int id)
    {
        if (hand.cards[id]==null)
            return;

        if (Input.GetButtonDown("PlayCard" + (id+1)))
        {
            hand.selectedCardId = id;

            pointerOverlay.SetOverlay(hand.cards[id].overlay);
        }
        if (Input.GetButtonUp("PlayCard" + (id+1)))
        {
            if (hand.selectedCardId == id)
            {
                hand.PlaySelectedCard(GetPlayPosition(),color);
                pointerOverlay.ClearOverlay();
            }
        }
    }

    public Vector2 GetPlayPosition()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
