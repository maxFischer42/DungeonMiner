using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchChance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int r = Random.Range(0, 20);
        if(18 > r)
        {
            Destroy(gameObject);
        }
        GetComponentInChildren<Light>().enabled = false;
	}
	

}
