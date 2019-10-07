using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToMenu : MonoBehaviour {

    public GameObject transitionObj;

    public void Return()
    {
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene("Surface");
    }
}
