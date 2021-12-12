using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
  [SerializeField]
  public int maxHealth = 300, currentHealth;
  public HealthBar healthBar;
  public GameObject slimeBallPrefab;
  public float targetRange = 10f, startTimeBtwShots;
  private float timeBtwnShots;
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
    if(Vector2.Distance(transform.position, target.position) < targetRange) {
		  if(timeBtwnShots <= 0){
        Vector3 shootPath = target.transform.position - transform.position;
        shootPath.Normalize();
        float angle = Mathf.Atan2(shootPath.y, shootPath.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.Euler(0f, 0f, angle);
        var slimeball = (GameObject) Instantiate(slimeBallPrefab, transform.position, rotation); 
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
