using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour {

    public float lifeTime;
    public float verticalDistance;
    Text text;
    float t;
    Vector2 startPosition;

    public void Init(int value)
    {
        text = GetComponent<Text>();
        text.text = value.ToString();
        startPosition = transform.position;
    }

	// Update is called once per frame
	void Update () {
        t += Time.deltaTime / lifeTime;
        Color color = text.color;
        color.a = Mathf.Lerp(1, 0, t);
        text.color = color;

        transform.position = Curves.QuadEaseOut(startPosition, startPosition + Vector2.up * verticalDistance, t);

        if (t >= 1)
            Destroy(gameObject);
	}
}
