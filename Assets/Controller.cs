using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    private InputControl inputs;
    private Rigidbody2D rig;
    public float playerSpeed;
    public float actionLength;

    public Item globalWeapon;

    public GameObject hitbox;

    public bool action = false;
    public bool doingAction = false;

    private GameObject hitboxObj;

    private void Start()
    {
        inputs = GetComponent<InputControl>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        if (!action)
        {
            action = checkAction();
            UpdateVelocity();
        }
        else if (action)
        {
            doAction();
        }
	}

    private bool checkAction()
    {
        bool value = false;
        if (inputs.fire1 != 0)
            value = true;
        return value;
    }

    private void doAction()
    {
        if (doingAction)
            return;
        doingAction = true;
        print("do action");
        rig.bodyType = RigidbodyType2D.Static;
        StartCoroutine(ActionTimer());
    }

    private void disableHitboxes()
    {
        rig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(hitboxObj.gameObject);
        hitboxObj = null;
        doingAction = false;
    }

    private void HitboxSet()
    {
        GameObject newHitbox = hitbox;
        Vector2 dir = new Vector2(inputs.xIn, inputs.yIn);
        hitboxObj = (GameObject)Instantiate(newHitbox, transform);
        Vector2 d;
        if (dir.x != 0 && dir.y != 0 || dir.x != 0)
        {
            //set priority to x axis
            if (dir.x > 0)
            {
                hitboxObj.GetComponent<BoxCollider2D>().offset = new Vector2(0.15f, 0);
                d = Vector2.right;
            }
            else
            {
                hitboxObj.GetComponent<BoxCollider2D>().offset = new Vector2(-0.15f, 0);
                d = Vector2.left;
            }
        }
        else if (dir.y != 0)
        {
            if (dir.y > 0)
            {
                hitboxObj.GetComponent<BoxCollider2D>().offset = new Vector2(0, 0.15f);
                d = Vector2.up;
            }
            else
            {
                hitboxObj.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.15f);
                d = Vector2.down;
            }
        }
        else
        {
            hitboxObj.GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.15f);
            d = Vector2.down;
        }
        if (globalWeapon._name != "DEFAULT") { 
            SendMessage("ActionAnimation", new ActionAnimParams(d, globalWeapon.data.tool, globalWeapon.data.type));
        } else
        {
            SendMessage("ActionAnimation", new ActionAnimParams(d, "", ""));
        }
    }

    IEnumerator ActionTimer()
    {
        HitboxSet();
        if(globalWeapon._name != "DEFAULT") 
            GameObject.Find("GameManager").GetComponent<AudioSource>().PlayOneShot(Resources.Load("Sound/Swing") as AudioClip);

        yield return new WaitForSeconds(actionLength);
        action = false;
        disableHitboxes();
    }

    void UpdateVelocity()
    {
        Vector2 vel = new Vector2(inputs.xIn, inputs.yIn);
        vel = vel * playerSpeed;
        rig.velocity = vel;
    }
}
