﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected Hand hand;

    public Color color;

	// Use this for initialization
	protected virtual void Awake () {
        hand = GetComponent<Hand>();
    }

    public void DrawACard()
    {
        hand.DrawFromDeck();
    }
}
