using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D Rigidb;
    public Animator animator;
    public Vector2 movement;

    void Start(){
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude); 
    }

    void FixedUpdate()
    {
        Rigidb.MovePosition(Rigidb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }
   
}
