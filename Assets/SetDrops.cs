using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDrops : MonoBehaviour
{

    private void Start()
    {
        int c = transform.childCount;
        for (int i = 0; i < c - 1; i++ )
        {
            int r = Random.Range(0, 90);
            if(r < 90 - PlayerPrefs.GetInt("f")) {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

}
