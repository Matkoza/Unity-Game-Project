using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{   
    [SerializeField] 
    public int maxHealth = 100, currentHealth;
    [SerializeField] 
    public float startTimeBtwShots, targetRange = 10f;
    private float timeBtwnShots;
    public HealthBar healthBar;
    public GameObject slimeBallPrefab;
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
        if(dest.CanSeePlayer() == true){
            if(timeBtwnShots <= 0){
                var slimeball = (GameObject) Instantiate(slimeBallPrefab, transform.position, Quaternion.identity); 
                timeBtwnShots = startTimeBtwShots;
            }
            else{
                timeBtwnShots -= Time.deltaTime;
            }
        }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
