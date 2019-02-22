using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2_ZombieAnimationController : MonoBehaviour {

    Animator animator;
    bool attack;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        attack = animator.GetBool("isBashing");
    }
	
	// Update is called once per frame
	void Update () {


        animator.SetBool("isBashing", attack);

        if (Input.GetKeyDown(KeyCode.B) == true && attack == false)
        {
            attack = true;
        }
        else if (Input.GetKeyDown(KeyCode.B) == true && attack == true)
        {
            attack = false;
        }


    }
}
