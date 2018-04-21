using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardClosestTarget : MonoBehaviour {

    [Header("Target")]

    [SerializeField]
    LayerMask targetsLayer;

    Health target;

    [Header("Movement")]

    public float speed;

    [Header("Attack")]

    public float attackTime;
    public float range;

    bool isAttacking;

	// Update is called once per frame
	void Update () {
        if (isAttacking)
            return;

        if (target == null)
            if (!FindTarget())
                return;

        Util.LookAt2D(transform, target.transform);

        if (Vector2.Distance(transform.position, target.transform.position) < range)
            StartCoroutine(StopAndAttack());
        else
            Move();
    }

    IEnumerator StopAndAttack()
    {
        isAttacking = true;
        SendMessage("Attack", target, SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(attackTime);
        isAttacking = false;
    }

    void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.Self);
    }

    bool FindTarget()
    {
        float minDistance = Mathf.Infinity;
        foreach(Health h in Board.Instance.livingObjects)
        {
            //Do not take allies into account
            if (h.tag == transform.tag)
                continue;

            float dist = Vector2.Distance(transform.position, h.transform.position);
            if (dist <= minDistance)
            {
                minDistance = dist;
                target = h;
            }
        }

        return target != null;
    }
}
