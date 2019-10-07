using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HandlePause : MonoBehaviour {

    public Canvas menu;

    public GameObject transitionObj;

    private bool isPaused = false;
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }	
        switch(isPaused)
        {
            case true:
                Time.timeScale = 0;
                menu.enabled = true;
                break;
            case false:
                Time.timeScale = 1;
                menu.enabled = false;
                break;
        }
	}

    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1;
        menu.enabled = false;
    }

    public void Return()
    {
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene("Surface");
        enabled = false;
    }
}
