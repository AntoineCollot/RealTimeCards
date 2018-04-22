using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public List<Health> livingObjects;

    public static Board Instance;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public void PlayCard(Card card, Vector2 position,GameObject summoner, Color color = default(Color))
    {
        if (!PlayArea.Instance.Contains(position) || card==null)
            return;

        switch (card.type)
        {
            case Card.Type.Monster:
                CardMonster cm = (CardMonster)card;
                Health newMonster = Instantiate(cm.monsterPrefab, position,Quaternion.identity);
                livingObjects.Add(newMonster);
                newMonster.GetComponentInChildren<SpriteRenderer>().color = color;
                newMonster.tag = summoner.tag;
                break;
            case Card.Type.Spell:
                CardSpell cs = (CardSpell)card;
                Transform spell = Instantiate(cs.effectPrefab, position, Quaternion.identity);
                spell.tag = summoner.tag;
                break;
            case Card.Type.Environment:
                break;
            default:
                break;
        }
    }
}
