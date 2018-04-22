using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHP;
    [HideInInspector]
    public int currentHP;

    public int targetedBy = 0;

	// Use this for initialization
	void Start () {
        currentHP = maxHP;
	}
	
	public void Damage(int amount)
    {
        amount = Mathf.Max(0, amount);

        currentHP -= amount;

        DamageTextSpawner.Instance.SpawnDamage(amount, transform.position);

        if (currentHP <= 0)
            gameObject.SendMessage("Die");
    }

    public void Die()
    {
        Board.Instance.livingObjects.Remove(this);
        Destroy(gameObject);
    }
}
