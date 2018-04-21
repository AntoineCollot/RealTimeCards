using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDamage : MonoBehaviour {

    public int damageValue;

    public void Attack(Health target)
    {
        target.Damage(damageValue);
    }
}
