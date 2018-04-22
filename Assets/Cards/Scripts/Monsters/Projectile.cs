using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public Transform target;

    public float travelTime;

    Vector3 startPosition;
    float t = 0;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        if (t >= 1 || target == null)
        {
            Destroy(gameObject);
            return;
        }

        t += Time.deltaTime / travelTime;
        transform.position = Curves.QuadEaseIn(startPosition, target.position, Mathf.Clamp01(t));
	}
}
