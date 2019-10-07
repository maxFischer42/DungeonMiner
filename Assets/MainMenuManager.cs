using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {

    public GameObject transitionObj;
    private string craftingScene = "SampleScene";
    private string mineScene = "Procedural";
    private string settingsScene = "Settings";

    public Item equipped;
    public Image previewWeapon;
    public GameObject prevDisplay;

    private void Start()
    {
        //PlayerPrefs.SetFloat("v", 0.5f);
        if(equipped._name != "DEFAULT")
        {
            previewWeapon.sprite = equipped.icon;
        }
        else
        {
            prevDisplay.SetActive(false);
        }
    }

    public void Craft()
    {
      //  GameObject.Find("Menu").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Select") as AudioClip);
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene(craftingScene);
    }

    public void Settings()
    {
    //    GameObject.Find("Menu").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Select") as AudioClip);
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene(settingsScene);
    }

    public void Exit()
    {
     //   GameObject.Find("Menu").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Select") as AudioClip);
        Application.Quit();
    }

    public void Mine()
    {
       // GameObject.Find("Menu").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Select") as AudioClip);
        PlayerPrefs.SetInt("f", 1);
        GameObject g = (GameObject)Instantiate(transitionObj);
        g.GetComponent<SceneTransition>().LoadScene(mineScene);
    }

}
