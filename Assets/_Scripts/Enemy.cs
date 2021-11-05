using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject slimeBallPrefab;
    float targetRange = 10f;
    private float timeBtwnShots;
    public float startTimeBtwShots;
    private Transform target;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < targetRange) {
				Fire();
				}
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Fire(){
        if (timeBtwnShots <= 0){
            var slimeball = (GameObject) Instantiate(slimeBallPrefab, transform.position, Quaternion.identity);  //transform.rotation);
            timeBtwnShots = startTimeBtwShots;
        }
        else {
            timeBtwnShots -= Time.deltaTime;
        }
    }
    
    
}
