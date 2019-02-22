using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week3_ZombieAnimationController : MonoBehaviour {

    Animator animator;
    public bool toDie = false;
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) <= 2.0f && toDie == false)
        {
            animator.SetBool("isBashing", true);
        }
        else
        {
            animator.SetBool("isBashing", false);
        }

        if (toDie == true) 
        {
            animator.SetBool("isDead", true);
        }

    }

}
