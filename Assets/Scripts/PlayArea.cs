using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea : MonoBehaviour {

    public float height;
    public float width;

    public static PlayArea Instance;

	// Use this for initialization
	void Awake () {
        Instance = this;
	}

    public bool Contains(Vector2 position)
    {
        return Mathf.Abs(position.x) < (width * 0.5f) && Mathf.Abs(position.y) < (height * 0.5f);
    }

    public Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(-width, width) * 0.5f, Random.Range(-height, height) * 0.5f);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, height, 0));
    }
#endif
}
