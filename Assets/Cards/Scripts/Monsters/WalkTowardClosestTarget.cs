using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTowardClosestTarget : MonoBehaviour {

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
        Health newTarget = null;
        int targetTargetedBy = 0;

        while(newTarget==null && targetTargetedBy<4)
        {
            foreach (Health h in Board.Instance.livingObjects)
            {
                //Do not take allies into account
                if (h.tag == transform.tag || h.targetedBy>targetTargetedBy)
                    continue;

                float dist = Vector2.Distance(transform.position, h.transform.position);
                if (dist <= minDistance)
                {
                    minDistance = dist;
                    newTarget = h;
                }
            }

            targetTargetedBy++;
        }

        SetTarget(newTarget);
        return newTarget != null;
    }

    void SetTarget(Health h)
    {
        if (target != null)
            target.targetedBy--;
        target = h;
        if (target != null)
            target.targetedBy++;
    }

    public void Die()
    {
        SetTarget(null);
    }
}
