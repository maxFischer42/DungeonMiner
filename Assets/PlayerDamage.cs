using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour {

    public float bumbSpeed = 1.5f;
    public InventoryManager inv;
    public Rigidbody2D rig;
    public Controller c;
    public Color hurtColor;
    public Color deathColor;
    public GameObject transition;
    public bool isDamaged = false;

    public GameObject lowNotice;

    private void Start()
    {
        inv = GameObject.Find("GameManager").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        int b = inv.items.Count;
        if (b < PlayerPrefs.GetInt("f"))
        {
            lowNotice.SetActive(true);
        }else
        {
            lowNotice.SetActive(false);
        }
    }

    IEnumerator kb(Vector2 dir)
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Hurt") as AudioClip);
        isDamaged = true;
        Color def = GetComponent<SpriteRenderer>().color;
        GetComponent<SpriteRenderer>().color = hurtColor;
        GetComponent<Controller>().enabled = false;
        GetComponent<PlayerAnimator>().enabled = false;
        c.enabled = false;
        rig.velocity = Vector2.zero;
        rig.velocity = dir;
        yield return new WaitForSeconds(0.5f);
        c.enabled = true;
        GetComponent<SpriteRenderer>().color = def;
        GetComponent<Controller>().enabled = true;
        GetComponent<PlayerAnimator>().enabled = true;
        isDamaged = false;
    }

    IEnumerator kill()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Death") as AudioClip);
        GetComponent<SpriteRenderer>().color = deathColor;
        GetComponent<Controller>().enabled = false;
        GetComponent<PlayerAnimator>().enabled = false;
        c.enabled = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("GameManager").GetComponent<InventoryManager>().Reset();        
        GameObject g = (GameObject)Instantiate(transition);
        g.GetComponent<SceneTransition>().LoadScene("Surface");

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            print("hit player");
            int b = inv.items.Count;
            if (b < PlayerPrefs.GetInt("f"))
            {
                print("kill player");
                StartCoroutine(kill());
            }
            else if(!isDamaged)
            {
                for (int i = 0; i < PlayerPrefs.GetInt("f"); i++)
                {
                    inv.items.RemoveAt(i);
                }
                Vector2 dir = gameObject.transform.position - collision.gameObject.transform.position;
                dir.Normalize();
                dir *= bumbSpeed * GetComponent<Controller>().playerSpeed;
                StartCoroutine(kb(dir));
            }

            
        }
    }
}
