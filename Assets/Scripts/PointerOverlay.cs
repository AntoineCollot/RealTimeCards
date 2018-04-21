using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerOverlay : MonoBehaviour {

    SpriteRenderer spriteRenderer;

    HumanPlayer player;

	// Use this for initialization
	void Awake () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponentInParent<HumanPlayer>();
	}

    void LateUpdate()
    {
        transform.position = player.GetPlayPosition();
    }
	
	public void SetOverlay(Sprite overlay)
    {
        spriteRenderer.enabled = true;
        spriteRenderer.sprite = overlay;
    }

    public void ClearOverlay()
    {
        spriteRenderer.sprite = null;
        spriteRenderer.enabled = false;
    }
}
