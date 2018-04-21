using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOnDeath : MonoBehaviour {

    public bool isPlayer;

	public void Die()
    {
        if(isPlayer)
        {
            GameManager.Instance.Loose();
        }
        else
        {
            GameManager.Instance.Win();
        }
    }
}
