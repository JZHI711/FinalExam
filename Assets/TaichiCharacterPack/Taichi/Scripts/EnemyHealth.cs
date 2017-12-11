using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int startHealth;
    public int currentHealth;


    Animator anim;
    ParticleSystem hitParticle;
    CapsuleCollider capssuleCollider;
    bool Die;

}
