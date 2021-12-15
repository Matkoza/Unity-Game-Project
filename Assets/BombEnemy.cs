using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BombEnemy : MonoBehaviour
{
    [SerializeField] 
    public int maxHealth = 100, currentHealth, damage;
    [SerializeField] 
    public float startTimeBtwShots, targetRange = 10f;
    private float timeBtwnShots;
    public HealthBar healthBar;
    //public GameObject slimeBallPrefab;
    private Transform target;
    
    
    void Start(){   
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();

        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }
    void Update(){
        if(healthBar.slider.value == 0){
            Destroy(gameObject);
        }
    }
    public void FixedUpdate(){
        var dest = this.gameObject.GetComponent<AIDestinationSetter>();
        // if(dest.CanSeePlayer() == true){
        //     if(timeBtwnShots <= 0){
        //         Vector3 shootPath = target.transform.position - transform.position;
        //         shootPath.Normalize();
        //         float angle = Mathf.Atan2(shootPath.y, shootPath.x) * Mathf.Rad2Deg;
        //         var rotation = Quaternion.Euler(0f, 0f, angle);
        //         var slimeball = (GameObject) Instantiate(slimeBallPrefab, transform.position, rotation); 
        //         timeBtwnShots = startTimeBtwShots;
        //     }
        //     else{
        //         timeBtwnShots -= Time.deltaTime;
        //     }
        // }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter2D(Collider2D other){   
        if (other.tag == "Player"){
            other.gameObject.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
        // if (other.tag == "Walls"){
        //     Destroy(gameObject);
        // }
    }

}
