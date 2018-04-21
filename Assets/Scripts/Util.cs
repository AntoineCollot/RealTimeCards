using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {

	public static void LookAt2D(Transform t, Transform target)
    {
        LookAt2D(t, target.position);
    }

    public static void LookAt2D(Transform t, Vector3 position)
    {
        Vector3 diff = position - t.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        t.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
