using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    float drawTimer;
    float gameTime = 0;

    public Player[] players;

	// Use this for initialization
	void Start () {
        drawTimer = GameSettings.maxDrawTime;
	}
	
	// Update is called once per frame
	void Update () {
        gameTime += Time.deltaTime;
        drawTimer -= Time.deltaTime;

        if(drawTimer<=0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].DrawACard();
            }

            drawTimer = Mathf.Lerp(GameSettings.maxDrawTime, GameSettings.minDrawTime, gameTime / GameSettings.maxToMinDrawTime);
        }

	}
}
