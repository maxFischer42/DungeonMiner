using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimate : MonoBehaviour {

    private Animator a;

	// Use this for initialization
	void Start () {
        a = GetComponent<Animator>();
	}
	
	public void PEnter()
    {
        a.SetBool("hl", true);
    }

    public void PExit()
    {
        a.SetBool("hl", false);
    }
}
