using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D theRB;
    [SerializeField] private float moveSpeed = 3f;
    private float lifeTimer;
    [SerializeField] private float maxLife = 2.0f;

    void Start(){   
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        Vector3 aim = (target.position - transform.position).normalized;
        theRB.velocity = aim * moveSpeed;
    }
    void Update(){  
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){   
        if (other.tag == "Player"){
            other.gameObject.GetComponent<Player>().TakeDamage(5);
            Destroy(gameObject);
        }
        if (other.tag == "Walls"){
            Destroy(gameObject);
        }
    }
}
