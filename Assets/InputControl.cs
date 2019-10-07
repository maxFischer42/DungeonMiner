using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public float xIn = 0f;
    public float yIn = 0f;
    public float fire1 = 0f;
    public float fire2 = 0f;

    public void Update()
    {
        xIn = Input.GetAxisRaw("Horizontal");
        yIn = Input.GetAxisRaw("Vertical");
        fire1 = Input.GetAxisRaw("Fire1");
        fire2 = Input.GetAxisRaw("Fire2");
    }
}

