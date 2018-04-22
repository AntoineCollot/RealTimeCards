using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAreaHit : MonoBehaviour {

    public LayerMask layer;

    public float radius;

    public bool hitAllies;

	// Use this for initialization
	void Start () {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, layer);

        foreach (Collider2D c in hit)
        {
            if(c.tag != tag || hitAllies)
            {
                Health h = c.GetComponent<Health>();
                if(h!=null)
                {
                    SendMessage("HitTarget", h);
                }
            }
        }
	}

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
#endif
}
