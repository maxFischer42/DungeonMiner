using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearLadder : MonoBehaviour {

    public GameObject ladder;
    public GameObject transitionObj;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            ladder.SetActive(true);
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.E))
        {
            PlayerPrefs.SetInt("f", PlayerPrefs.GetInt("f") + 1);
            GameObject g = (GameObject)Instantiate(transitionObj);
            g.GetComponent<SceneTransition>().LoadScene("Procedural");
        }
    }



    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ladder.SetActive(false);
        }
    }
}
