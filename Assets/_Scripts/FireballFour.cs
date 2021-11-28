using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballFour : MonoBehaviour
{  
    public float moveSpeed = 3f;
    public Rigidbody2D theRB;
    private float lifeTimer;
    
    [SerializeField] private float maxLife = 1.5f;
    void Update()
    {
        theRB.velocity = transform.right *moveSpeed;
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (other.tag == "Boss"){
            other.gameObject.GetComponent<Boss>().TakeDamage(20);
            Destroy(gameObject);
        }
        else if (other.tag == "Walls"){
            Destroy(gameObject);
        }
    }
}

