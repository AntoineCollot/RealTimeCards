using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    [HideInInspector]
    public int currentHP;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;
	}
	
	public void Damage(int amount)
    {
        amount = Mathf.Max(0, amount);

        currentHP -= amount;

        if (currentHP <= 0)
            gameObject.SendMessage("Die");
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
