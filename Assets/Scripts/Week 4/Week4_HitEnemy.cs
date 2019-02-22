using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week4_HitEnemy : MonoBehaviour {


    private Animator animator;
    private Week3_AITargetController enemyScript;



    void Start()
    {

        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }



    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("punch");
        }
      

    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.tag == "Zombie" )
        {
            if(animator.GetCurrentAnimatorClipInfo(1)[0].clip.name == "Punching (1)")
            {
                
                collider.gameObject.GetComponent<Week4_AITargetController>().kill();

            }


        }
    }
    }
