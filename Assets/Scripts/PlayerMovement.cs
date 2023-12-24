using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float mvSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        if (movement.x !=0){
            animator.SetFloat("lastX",movement.x);
        }

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);

    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + movement * mvSpeed * Time.fixedDeltaTime);
    }

}
