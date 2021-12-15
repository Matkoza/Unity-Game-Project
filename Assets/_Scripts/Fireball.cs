using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fireball : MonoBehaviour
{  
    [SerializeField] 
    public float moveSpeed = 3f, maxLife = 2.0f, lifeTimer;
    public Transform up, down, left, right;
    public GameObject fireballFourPrefab;
    public Rigidbody2D theRB;
    public Vector3 positionHolder;
    void Update()
    {
        theRB.velocity = transform.right * moveSpeed;
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= maxLife){
            positionHolder = transform.position;
            SpawnBalls(positionHolder);
            Destroy(gameObject);
        }  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.tag == "Enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (other.tag == "BombEnemy"){
            other.gameObject.GetComponent<BombEnemy>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (other.tag == "Boss"){
            other.gameObject.GetComponent<Boss>().TakeDamage(20);
            Destroy(gameObject);
        }
        if (other.tag == "Walls"){
            positionHolder = transform.position;
            SpawnBalls(positionHolder);
            Destroy(gameObject);
        }
    }
    public void SpawnBalls(Vector3 spawnPosition){
            GameObject fireballRight = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathr = right.position - spawnPosition;
            fireballRight.transform.position = right.position;
            float angler = Mathf.Atan2(shootPathr.y, shootPathr.x) * Mathf.Rad2Deg;
            fireballRight.transform.rotation = Quaternion.Euler(0, 0, angler);

            GameObject fireballUp = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathu = up.position - spawnPosition;
            fireballUp.transform.position = up.position;
            float angleu = Mathf.Atan2(shootPathu.y, shootPathu.x) * Mathf.Rad2Deg;
            fireballUp.transform.rotation = Quaternion.Euler(0, 0, angleu);

            GameObject fireballLeft = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathl = left.position - spawnPosition;
            fireballLeft.transform.position =left.position;
            float anglel = Mathf.Atan2(shootPathl.y, shootPathl.x) * Mathf.Rad2Deg;
            fireballLeft.transform.rotation = Quaternion.Euler(0, 0, anglel);
            
            // GameObject fireballDown = Instantiate(fireballFourPrefab) as GameObject;
            // Vector3 shootPathd = down.position - spawnPosition;
            // fireballDown.transform.position = down.position;
            // float angled = Mathf.Atan2(shootPathd.y, shootPathd.x) * Mathf.Rad2Deg;
            // fireballDown.transform.rotation = Quaternion.Euler(0, 0, angled);
    }
}

