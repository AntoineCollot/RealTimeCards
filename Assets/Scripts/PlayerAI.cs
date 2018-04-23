using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : Player {

    public float minPlayACardChance;
    public float maxPlayACardChance;

    public float maxLoosingMultiplier;

    public float monsterSpawnDistance;

    void Update()
    {
        int cardCount = hand.cardCount;
        if (cardCount <= 0)
            return;

        float rand = Random.Range(0, 1.0f);

        //Play more cards when loosing
        int monsterDiff = 0;
        foreach (Health h in Board.Instance.livingObjects)
        {
            if (h.tag == tag)
            {
                monsterDiff--;
            }
            else
            {
                monsterDiff++;
            }
        }
       
        float loosingMultiplier = Mathf.Lerp(1, maxLoosingMultiplier,(float)Mathf.Max(monsterDiff,0)/ Board.Instance.livingObjects.Count);

        if(rand<=Mathf.Lerp(minPlayACardChance,maxPlayACardChance, cardCount / GameSettings.maxHandCardCount)*Time.deltaTime* loosingMultiplier)
        {
            PlayRandomCard();
        }
    }

    void PlayRandomCard()
    {
        Health target = GetMostDangerousTarget();
        if (target == null)
            return;


        int cardToPlay = hand.GetRandomCardId();

        Vector3 position = Vector3.zero;
        switch (hand.cards[cardToPlay].type)
        {
            case Card.Type.Monster:
                position = target.transform.position + new Vector3(Random.Range(-1, 1.0f), Random.Range(-1, 1.0f), 0).normalized * monsterSpawnDistance;

                if(!hand.CanPlayCardThere(cardToPlay,position))
                {
                    position = hand.localPlayArea.GetRandomPosition();
                }
                break;
            case Card.Type.Spell:
                position = target.transform.position;
                break;
            case Card.Type.Environment:
                position = Vector3.zero;
                break;
            default:
                break;
        }

        hand.PlayCard(cardToPlay, position,color);
    }

    Health GetMostDangerousTarget()
    {
        float minDist = Mathf.Infinity;
        Health target = null;
        foreach(Health h in Board.Instance.livingObjects)
        {
            if (h.tag == transform.tag)
                continue;

            float dist = Vector2.Distance(transform.position, h.transform.position);
            if(dist<= minDist)
            {
                minDist = dist;
                target = h;
            }
        }
        return target;
    }
}
