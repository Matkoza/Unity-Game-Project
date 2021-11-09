using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FireballFour : MonoBehaviour
{  
    public float moveSpeed = 3f;
    //public GameObject fireballPrefab;
    //public Transform fireballPoint;
    public Rigidbody2D theRB;
   // public int damage = 5;
    private float lifeTimer;
    public Vector3 positionHolder;
    
    [SerializeField] private float maxLife = 1.5f;
    //public bool isSpawnable = false;
    //public Vector2Int fireballsSpawnLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = transform.right *moveSpeed;
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife){
           // if (isSpawnable == true){
               // SpawnBalls(transform.position);
                Destroy(gameObject);
              //  SpawnFourFireballs sffb = GetComponent<SpawnFourFireballs>();
              //  sffb.SpawnBalls(transform.position);
           // }

            
            //Debug.Log("TimerPassed");
            //lifeTimer = 0f;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Enemy"){
            Debug.Log("Hit");
            
            other.gameObject.GetComponent<Enemy>().TakeDamage(20);
            Destroy(gameObject);
        }
        else if (other.tag == "Walls"){
            Destroy(gameObject);
        }
    }

    void OnDestroy(){
          //  SpawnFourFireballs sffb = GetComponent<SpawnFourFireballs>();
         //   sffb.SpawnBalls(transform.position);
    }
    public void SetIsSpawnable(bool spawnable){
        //isSpawnable = spawnable;
    }

}

