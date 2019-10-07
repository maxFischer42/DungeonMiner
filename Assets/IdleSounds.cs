using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleSounds : MonoBehaviour {

    public Vector2 delayRange = new Vector2(20, 400);
    private float target;
    private float timer;

	// Use this for initialization
	void Start () {
        setDelay();
	}

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= target)
        {
            setDelay();
            playAmbience();
        }
    }

    void setDelay()
    {
        timer = 0f;
        target = Random.Range(delayRange.x, delayRange.y);
    }

    public void playAmbience()
    {
        int i = Random.Range(0, 4);
        string a = "Sound/Ambient1";
        switch(i)
        {
            case 0:
                a = "Sound/Ambience1";
                break;
            case 1:
                a = "Sound/Ambience2";
                break;
            case 2:
                a = "Sound/Ambience3";
                break;
            case 3:
                a = "Sound/Ambience4";
                break;
        }
        print(a);
        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load(a) as AudioClip);
    }
   
  
}
