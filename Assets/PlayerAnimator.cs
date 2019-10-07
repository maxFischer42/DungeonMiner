using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    public RuntimeAnimatorController Idle;
    public GameObject dLight;
    public RuntimeAnimatorController Down;
    public RuntimeAnimatorController Left;
    public GameObject lLight;
    public RuntimeAnimatorController Right;
    public GameObject rLight;
    public RuntimeAnimatorController Up;
    public GameObject uLight;

    public Controller controller;
    public InputControl input;
    public Animator anim;

    public RuntimeAnimatorController[] noWeapon;

    public RuntimeAnimatorController[] woodAxe;
    public RuntimeAnimatorController[] woodPickaxe;
    public RuntimeAnimatorController[] woodSword;

    public RuntimeAnimatorController[] copperAxe;
    public RuntimeAnimatorController[] copperPickaxe;
    public RuntimeAnimatorController[] copperSword;

    public RuntimeAnimatorController[] ironAxe;
    public RuntimeAnimatorController[] ironPickaxe;
    public RuntimeAnimatorController[] ironSword;

    public RuntimeAnimatorController[] platAxe;
    public RuntimeAnimatorController[] platPickaxe;
    public RuntimeAnimatorController[] platSword;

    // Update is called once per frame
    void Update()
    {
        if (!controller.action)
        {
            if (input.xIn != 0)
            {
                if (input.xIn > 0)
                {
                    anim.runtimeAnimatorController = Right;
                    dLight.SetActive(false);
                    lLight.SetActive(false);
                    rLight.SetActive(true);
                    uLight.SetActive(false);
                }
                else
                {
                    anim.runtimeAnimatorController = Left;
                    dLight.SetActive(false);
                    lLight.SetActive(true);
                    rLight.SetActive(false);
                    uLight.SetActive(false);
                }
            }
            else if (input.yIn != 0)
            {
                if (input.yIn > 0)
                {
                    anim.runtimeAnimatorController = Up;
                    dLight.SetActive(false);
                    lLight.SetActive(false);
                    rLight.SetActive(false);
                    uLight.SetActive(true);
                }
                else
                {
                    anim.runtimeAnimatorController = Down;
                    dLight.SetActive(true);
                    lLight.SetActive(false);
                    rLight.SetActive(false);
                    uLight.SetActive(false);
                }
            }
            else
            {
                anim.runtimeAnimatorController = Idle;
                dLight.SetActive(true);
                lLight.SetActive(false);
                rLight.SetActive(false);
                uLight.SetActive(false);
            }
        }
    }

    public void ActionAnimation(ActionAnimParams @params)
    {
        
        if (input.xIn != 0)
        {
            int i = 0;
            if (input.xIn > 0)
            {
                dLight.SetActive(false);
                lLight.SetActive(false);
                rLight.SetActive(true);
                uLight.SetActive(false);
                switch (@params.tool)
                {
                    case "pickaxe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodPickaxe[3];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperPickaxe[3];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironPickaxe[3];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platPickaxe[3];
                                break;
                        }
                        break;
                    case "axe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodAxe[3];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperAxe[3];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironAxe[3];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platAxe[3];
                                break;
                        }
                        break;
                    case "sword":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodSword[3];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperSword[3];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironSword[3];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platSword[3];
                                break;
                        }
                        break;
                    case "def":
                        anim.runtimeAnimatorController = noWeapon[3];
                        break;
                }

            }
            else
            {
                dLight.SetActive(false);
                lLight.SetActive(true);
                rLight.SetActive(false);
                uLight.SetActive(false);
                switch (@params.tool)
                {
                    case "pickaxe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodPickaxe[1];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperPickaxe[1];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironPickaxe[1];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platPickaxe[1];
                                break;
                        }
                    break;
                    case "axe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodAxe[1];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperAxe[1];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironAxe[1];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platAxe[1];
                                break;
                        }
                    break;
                    case "sword":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodSword[1];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperSword[1];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironSword[1];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platSword[1];
                                break;
                        }
                    break;
                    case "def":
                        anim.runtimeAnimatorController = noWeapon[1];
                        break;
                }
            }
        }
        else if (input.yIn != 0)
        {
            if (input.yIn > 0)
            {
                dLight.SetActive(false);
                lLight.SetActive(false);
                rLight.SetActive(false);
                uLight.SetActive(true);
                switch (@params.tool)
                {
                    case "pickaxe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodPickaxe[2];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperPickaxe[2];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironPickaxe[2];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platPickaxe[2];
                                break;
                        }
                    break;
                    case "axe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodAxe[2];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperAxe[2];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironAxe[2];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platAxe[2];
                                break;
                        }
                    break;
                    case "sword":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodSword[2];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperSword[2];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironSword[2];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platSword[2];
                                break;
                        }
                    break;
                    case "def":
                        anim.runtimeAnimatorController = noWeapon[2];
                        break;
                }
            }
            else
            {
                dLight.SetActive(true);
                lLight.SetActive(false);
                rLight.SetActive(false);
                uLight.SetActive(false);
                switch (@params.tool)
                {
                    case "pickaxe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodPickaxe[0];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperPickaxe[0];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironPickaxe[0];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platPickaxe[0];
                                break;
                        }
                    break;
                    case "axe":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodAxe[0];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperAxe[0];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironAxe[0];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platAxe[0];
                                break;
                        }
                    break;
                    case "sword":
                        switch (@params.type)
                        {
                            case "wood":
                                anim.runtimeAnimatorController = woodSword[0];
                                break;
                            case "copper":
                                anim.runtimeAnimatorController = copperSword[0];
                                break;
                            case "iron":
                                anim.runtimeAnimatorController = ironSword[0];
                                break;
                            case "plat":
                                anim.runtimeAnimatorController = platSword[0];
                                break;
                        }
                    break;
                }
            }
        }
        else
        {
            switch (@params.tool)
            {
                case "pickaxe":
                    switch (@params.type)
                    {
                        case "wood":
                            anim.runtimeAnimatorController = woodPickaxe[0];
                            break;
                        case "copper":
                            anim.runtimeAnimatorController = copperPickaxe[0];
                            break;
                        case "iron":
                            anim.runtimeAnimatorController = ironPickaxe[0];
                            break;
                        case "plat":
                            anim.runtimeAnimatorController = platPickaxe[0];
                            break;
                    }
                break;
                case "axe":
                    switch (@params.type)
                    {
                        case "wood":
                            anim.runtimeAnimatorController = woodAxe[0];
                            break;
                        case "copper":
                            anim.runtimeAnimatorController = copperAxe[0];
                            break;
                        case "iron":
                            anim.runtimeAnimatorController = ironAxe[0];
                            break;
                        case "plat":
                            anim.runtimeAnimatorController = platAxe[0];
                            break;
                    }
                break;
                case "sword":
                    switch (@params.type)
                    {
                        case "wood":
                            anim.runtimeAnimatorController = woodSword[0];
                            break;
                        case "copper":
                            anim.runtimeAnimatorController = copperSword[0];
                            break;
                        case "iron":
                            anim.runtimeAnimatorController = ironSword[0];
                            break;
                        case "plat":
                            anim.runtimeAnimatorController = platSword[0];
                            break;
                    }
                break;
                case "def":
                    anim.runtimeAnimatorController = noWeapon[0];
                    break;
            }
            dLight.SetActive(true);
            lLight.SetActive(false);
            rLight.SetActive(false);
            uLight.SetActive(false);
            
        }
        anim.speed = 0.9f;
    }
}

public class ActionAnimParams {
    public Vector2 direction;
    public string tool;
    public string type;

    public ActionAnimParams(Vector2 d, string w, string t)
    {
        this.direction = d;
        this.tool = w;
        this.type = t;
    }
}
