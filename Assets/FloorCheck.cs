using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCheck : MonoBehaviour {
	void Update () {
        GetComponent<Text>().text = "Floor " + PlayerPrefs.GetInt("f").ToString();
	}
}
