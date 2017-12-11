﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
   // EnemyAttack enemyAttack;
    Animator anim;
    CapsuleCollider capsuleCollider;
    bool Ismoving ;
    UnityEngine.AI.NavMeshAgent nav;
    enum AIStatus {Idle,Run,Hit,Damage}
    /*------------------------*/
    public int seeRange = 3;
    public int attackRange = 1;
    /*------------------------*/

    void Awake()
    {

     player = GameObject.FindGameObjectWithTag("Player").transform;
     playerHealth = player.GetComponent<PlayerHealth>();
     enemyHealth = GetComponent<EnemyHealth>();
    // enemyAttack = GetComponent<EnemyAttack>();
     nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
     anim = GetComponent<Animator>();
     
    }
   
    void Update (){
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            if (Vector3.Distance(transform.position, player.position) < seeRange)
            {
                Move();
                nav.SetDestination(player.position);

            } else if (Vector3.Distance(transform.position, player.position)<attackRange)
            {
                
            }
            else
            {
                
            }
            nav.enabled = false;
            UnMove();
        }
        else
        {
           
        }
	}
    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, seeRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    void Move()
    {
        Ismoving = true;
        anim.SetBool("Moving", Ismoving);
    }
    void UnMove() {
        Ismoving = false;
        anim.SetBool("Moving", Ismoving);
    }
}
