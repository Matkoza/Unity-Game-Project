using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] 
    public int maxHealth = 100, currentHealth;
    public HealthBar healthBar;
    public GameObject slimeBallPrefab;
    public float targetRange = 10f;
    private float timeBtwnShots;
    public float startTimeBtwShots;
    private Transform target;
    void Start()
    {   
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
    }
    void Update()
    {
      if (healthBar.slider.value == 0){
          Destroy(gameObject);
      }

        
    }
    public void FixedUpdate(){
        if(Vector2.Distance(transform.position, target.position) < targetRange) {
				if (timeBtwnShots <= 0){
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
