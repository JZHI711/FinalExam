using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
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
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
   
    void Update (){
        if (Vector3.Distance(transform.position, player.position) < seeRange)
        {
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                nav.SetDestination(player.position);

            }
            else
            {
                nav.enabled = false;
            }
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

}
