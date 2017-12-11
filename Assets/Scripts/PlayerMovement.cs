using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody rigid;
    private Animator animator;
    public float speed = 6f;
    private int groundLayerMask;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        var movement = new Vector3(h, 0, v) * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);
    }

    private void Turning()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if(Physics.Raycast(ray, out raycastHit, 100f, groundLayerMask))
        {
            var playerLookDir = raycastHit.point - transform.position;
            playerLookDir.y = 0f;
            Quaternion lookRotation = Quaternion.LookRotation(playerLookDir);
            rigid.MoveRotation(lookRotation);
        }
    }

    private void Animating(float h, float v)
    {
        var isMoving = h != 0 || v != 0;
        animator.SetBool("IsMoving", isMoving);
    }
}
