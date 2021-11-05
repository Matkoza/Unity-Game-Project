using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slimeball : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform target;
    public Rigidbody2D theRB;
    [SerializeField] private float moveSpeed;
    private float lifeTimer;
    [SerializeField] private float maxLife = 2.0f;

    void Start()
    {   
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        // Aim bullet in player's direction.
        //transform.LookAt(target.position);
        
    }

    // Update is called once per frame
    void Update()
    {  
        Vector3 aim = (target.position - transform.position).normalized;
        // Add force based on that direction, modifying it as needed.
        theRB.AddForce(aim * moveSpeed);
        //transform.position += transform.forward * moveSpeed * Time.deltaTime;
        //transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed* Time.deltaTime);
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife){
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Player"){
            
            other.gameObject.GetComponent<Player>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
