using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballFour : MonoBehaviour
{  
    public float moveSpeed = 3f;
    public Rigidbody2D theRB;
   // public int damage = 5;
    private float lifeTimer;
    public Vector3 positionHolder;
    
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
        else if (other.tag == "Walls"){
            Destroy(gameObject);
        }
    }
}

