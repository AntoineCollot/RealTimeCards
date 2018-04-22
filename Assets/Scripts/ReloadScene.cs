using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

    public float delay;

	// Use this for initialization
	void Start () {
        Invoke("Reload", delay);
	}
	
    void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
