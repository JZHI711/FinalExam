using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;


    Animator anim;
    ParticleSystem hitParticle;
    CapsuleCollider capssuleCollider;
    bool Die;

    void Awake()
    {
        anim = GetComponent<Animator>();
        currentHealth = startingHealth;
    }
    void Update()
    {
        if (currentHealth==0)
        {
            anim.SetTrigger("Die");
        }

    }
}