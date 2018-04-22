using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDamage : MonoBehaviour {

    public int power;

    public void HitTarget(Health h)
    {
        h.Damage(power);
    }
}
