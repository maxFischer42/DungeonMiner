using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopup : MonoBehaviour {

    public float length;
    public Image icon;
    public Text sp;
    public float move = 0.02f;

    private float timer = 0f;

    private void Start()
    {
        timer = length;
    }

    // Update is called once per frame
    void Update () {
        transform.SetPositionAndRotation(new Vector2(transform.position.x, transform.position.y + move), Quaternion.identity);
        timer -= Time.deltaTime;
        Color c = sp.color;
        Color b = icon.color;
        c.a = timer;
        b.a = timer;
        sp.color = c;
        icon.color = b;
        if(timer <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void SetInfo(Sprite s)
    {
        icon.sprite = s;
    }
}
