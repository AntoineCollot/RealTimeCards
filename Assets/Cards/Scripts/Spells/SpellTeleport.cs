using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellTeleport : MonoBehaviour {

    public void HitTarget(Health h)
    {
        h.transform.position = PlayArea.Instance.GetRandomPosition();
        h.SendMessage("OnDisplaced", SendMessageOptions.DontRequireReceiver);
    }
}
