using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDrop : MonoBehaviour {

    public void Start()
    {
        int c = transform.childCount;
        int r = Random.Range(0, c);
        for(int i = 0; i < c; i++)
        {
            if (i == r)
            {
                if (transform.GetChild(i).name != "EnSpawn")
                {
                    transform.GetChild(i).SetPositionAndRotation(new Vector3(transform.GetChild(i).transform.position.x, transform.GetChild(i).transform.position.y, -0.4f), Quaternion.identity);
                    transform.GetChild(i).GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    transform.GetChild(i).GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                }
                if ((transform.GetChild(i).gameObject.name.ToLower().Contains("copp") && PlayerPrefs.GetInt("f") < 3)
                || (transform.GetChild(i).gameObject.name.ToLower().Contains("iron") && PlayerPrefs.GetInt("f") < 6) ||
                (transform.GetChild(i).gameObject.name.ToLower().Contains("plat") && PlayerPrefs.GetInt("f") < 9))
                {
                    Destroy(transform.GetChild(i).gameObject);
                }
                continue;
            }
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
