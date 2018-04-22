using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchHP : MonoBehaviour {

    public Health target;

    Text hpText;
	
    void Awake()
    {
        hpText = GetComponent<Text>();
    }

	// Update is called once per frame
	void Update () {
        hpText.text = target.currentHP.ToString();
    }
}
