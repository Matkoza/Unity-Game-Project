using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject slimeBallPrefab;
    [SerializeField] float targetRange = 10f;
    private float timeBtwnShots;
    public float startTimeBtwShots;
    private Transform target;
    public Transform firePoint;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //transform.LookAt(target.position);
    }

    // Update is called once per frame
    void Update()
    {
      if (healthBar.slider.value == 0){
          Destroy(gameObject);
      }
        
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void FixedUpdate(){
      //  Vector3 shootPath = target.position - transform.position;
      //  shootPath.Normalize();
       // float angle = Mathf.Atan2(shootPath.y, shootPath.x) * Mathf.Rad2Deg;
       // transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if(Vector2.Distance(transform.position, target.position) < targetRange) {
				if (timeBtwnShots <= 0){
                    var slimeball = (GameObject) Instantiate(slimeBallPrefab, transform.position, Quaternion.identity); //Quaternion.identity);  
                        timeBtwnShots = startTimeBtwShots;
                }
                else {
                    timeBtwnShots -= Time.deltaTime;
                }
		}
        
    }
    
    
}
