using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellAreaHit : MonoBehaviour {

    public float radius;

	// Use this for initialization
	void Start () {
        Physics2D.OverlapCircleAll(transform.position, radius);
	}
}
