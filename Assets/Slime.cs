using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour {

    public int HP;
    private Transform player;
    private Rigidbody2D rig;
    public float chaseSpeed;
    public Color hurtColor;
    public bool notHit = true;

    private void Start()
    {
        player = GameObject.Find("Player(Clone)").transform;
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (notHit) {
            Vector2 v = player.position - transform.position;
            v.Normalize();
            v *= chaseSpeed;
            rig.velocity = v;
        }
    }

    IEnumerator handleHit()
    {
        notHit = false;
        Color de = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = hurtColor;
        Weapon data = GameObject.Find("GameManager").GetComponent<InventoryManager>().current.data;
        Vector2 kb = (transform.position - player.position);
        kb.Normalize();
        kb *= data.knockback;
        rig.velocity = kb;
        HP -= data.damage;
        yield return new WaitForSeconds(data.delay);       
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        GetComponent<SpriteRenderer>().color = de;
        notHit = true;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerHB")
        {
            StartCoroutine(handleHit());
            GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Slime") as AudioClip);

        }
    }
}
