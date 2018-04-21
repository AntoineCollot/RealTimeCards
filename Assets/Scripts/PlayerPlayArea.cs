using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlayArea : MonoBehaviour {

    public Vector3 offset;

    public float height;
    public float width;

    public bool Contains(Vector2 position)
    {
        return Mathf.Abs(position.x + offset.x) < (width * 0.5f) && Mathf.Abs(position.y + offset.y) < (height * 0.5f);
    }

    public Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-width, width) * 0.5f -offset.x, Random.Range(-height, height) * 0.5f - offset.y);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + offset, new Vector3(width, height, 0));
    }
#endif
}
