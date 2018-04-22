using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    float drawTimer;
    float gameTime = 0;

    public Player[] players;

    [Header("Start")]

    public int startCardCount;

    public UnityEvent onGameStart = new UnityEvent();

    bool gameHasStarted = false;

    [Header("Victory")]

    [SerializeField]
    GameObject panelWin;

    [SerializeField]
    GameObject panelLoss;

    [HideInInspector]
    public bool gameIsOver = false;

    public UnityEvent onGameOver = new UnityEvent();

    public static GameManager Instance;

    void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        drawTimer = GameSettings.maxDrawTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameHasStarted || gameIsOver)
            return;

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

    public void StartGame()
    {
        onGameStart.Invoke();

        gameHasStarted = true;

        for (int c = 0; c < startCardCount; c++)
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].DrawACard();
            }
        }
    }

    public void Win()
    {
        enabled = false;
        panelWin.SetActive(true);
        gameIsOver = true;
    }

    public void Loose()
    {
        enabled = false;
        panelLoss.SetActive(true);
        gameIsOver = true;
    }
}
