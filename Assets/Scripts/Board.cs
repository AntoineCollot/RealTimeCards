﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public List<Health> livingObjects;

    public static Board Instance;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public void PlayCard(Card card, Vector2 position)
    {
        if (!PlayArea.Instance.Contains(position))
            return;

        switch (card.type)
        {
            case Card.Type.Monster:
                CardMonster c = (CardMonster)card;
                Health newMonster = Instantiate(c.monsterPrefab, position,Quaternion.identity);
                livingObjects.Add(newMonster);
                break;
            case Card.Type.Spell:
                break;
            case Card.Type.Environment:
                break;
            default:
                break;
        }
    }
}
