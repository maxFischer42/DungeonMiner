using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour {

    private Slider s;

    private void Start()
    {
        s = GetComponent<Slider>();
        s.value = PlayerPrefs.GetFloat("v");
    }

    public void changeVol()
    {
        PlayerPrefs.SetFloat("v", s.value);
        s.value = PlayerPrefs.GetFloat("v");
    }
}
