using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour {

    Vector3 lastPosition;
    Animator anim;
	
    void Start()
    {
        lastPosition = transform.position;
        anim = GetComponentInChildren<Animator>();
    }

	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(lastPosition,transform.position)>0.01f)
        {
            anim.SetBool("Walk", true);
        }
        lastPosition = transform.position;

    }

    public void Attack(Health target)
    {
        anim.SetTrigger("Attack");
    }
}
