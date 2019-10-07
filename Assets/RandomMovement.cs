using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public Vector2 timeToRandom = new Vector2();
    public Rigidbody2D rig;
    private float timer;
    private float currentTarget;
    public float speed;

    private int mult;

    private void Start()
    {
        mult = PlayerPrefs.GetInt("f");
        rig = GetComponent<Rigidbody2D>();
        currentTarget = timeToRandom.x;
    }

    // Update is called once per frame
    void Update () {
        timer += Time.deltaTime;
        if (timer >= currentTarget)
        {
            timer = 0;
            currentTarget = Random.Range(timeToRandom.x, timeToRandom.y);
            Vector2 v = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * speed;
            rig.velocity = v;
        }
    }
}
