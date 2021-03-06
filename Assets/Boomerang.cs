using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    [SerializeField] 
    public float maxLife = 1.5f, moveSpeed = 3f;
    private float lifeTimer;
    public Rigidbody2D theRB;
    
    void Update()
    {
        theRB.velocity = transform.right * moveSpeed;
        lifeTimer += Time.deltaTime;
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
