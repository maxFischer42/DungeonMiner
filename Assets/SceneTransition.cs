using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    public Image fadeObj;
    private bool isActive;
    private string sceneToLoad;
    public float fadelength =1f;
    public float mult = 0.1f;
    public float timer;

    // Update is called once per frame
    void Update ()
    {
		if(isActive)
        {
            timer += (1 * mult) / fadelength;
            Color newColor = fadeObj.color;
            newColor.a = timer;
            fadeObj.color = newColor;
            if(timer >= 1)
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
	}

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        isActive = true;
        sceneToLoad = sceneName;
    }
}
