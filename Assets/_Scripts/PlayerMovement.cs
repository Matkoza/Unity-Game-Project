using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    private enum State {
        Normal,
        Rolling,
    }
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public Vector3 rollDir, moveDir;
    private float rollSpeed;
    private float dashTime;
    [SerializeField]
    public float startDashTime = 1.5f;
    public bool isDashing;
    private State state; 
    void Awake(){
        rb = GetComponent<Rigidbody2D>();
        state = State.Normal;
    }
    
    void Update(){
        switch(state){  
        case State.Normal:
            float moveX = 0f;
            float moveY = 0f;
            if(Input.GetKey(KeyCode.W)){
                moveY = 1f;
            }
            if(Input.GetKey(KeyCode.S)){
                moveY = -1f;
            }
            if(Input.GetKey(KeyCode.A)){
                moveX = -1f;
            }
            if(Input.GetKey(KeyCode.D)){
                moveX = 1f;
            }
            moveDir = new Vector3(moveX, moveY).normalized;

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetKeyDown(KeyCode.F)){
                isDashing = true;
            }
                if(dashTime <= 0){
                    if (Input.GetKeyDown(KeyCode.Space)){
                        rollDir = moveDir;
                        rollSpeed = 30f;
                        dashTime = startDashTime;
                        state = State.Rolling;
                    }
                }
                else{
                    dashTime -= Time.deltaTime;
                }
            
            break;
        case State.Rolling:
            float rollSpeedDropMultiplier = 5f;
            rollSpeed -= rollSpeed * rollSpeedDropMultiplier * Time.deltaTime;
            
            float rollSpeedMinimum = 10f;
            if(rollSpeed < rollSpeedMinimum){
                state = State.Normal;
            }
            break;
        }
    }

    void FixedUpdate(){   
        switch(state){
        case State.Normal:
            rb.velocity = moveDir * moveSpeed; 
            if(isDashing){
                float dashAmount = 25f;
                Vector3 dashPosition = transform.position + moveDir * dashAmount;
                rb.MovePosition(dashPosition);
                isDashing = false;
            }
            break;
        case State.Rolling:
            rb.velocity = rollDir * rollSpeed;
            break;
        }  
    }
}
   
