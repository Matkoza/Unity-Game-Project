using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fireball : MonoBehaviour
{  
    public float moveSpeed = 3f;
    public Transform up, down, left, right;
    public GameObject fireballFourPrefab;
    public Rigidbody2D theRB;
    //public int damage = 5;
    private float lifeTimer;
    public Vector3 positionHolder;
    [SerializeField] private float maxLife = 2.0f;

    void Update()
    {
        theRB.velocity = transform.right *moveSpeed;
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
        if (other.tag == "Boss"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(20);
            Destroy(gameObject);
        }
        else if (other.tag == "Walls"){
            positionHolder = transform.position;
            SpawnBalls(positionHolder);
            Destroy(gameObject);
        }
    }


    public void SpawnBalls(Vector3 spawnPosition){

           // var fireballRight = (GameObject) Instantiate(fireballFourPrefab, right.position- transform.localPosition, transform.rotation= Quaternion.Euler(0, 0, 0)); //= Quaternion.Euler(0, 0, 0));
            GameObject fireballRight = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathr = right.position - spawnPosition;
            //shootPathr.Normalize();
            fireballRight.transform.position = right.position;
            float angler = Mathf.Atan2(shootPathr.y, shootPathr.x) * Mathf.Rad2Deg;
            fireballRight.transform.rotation = Quaternion.Euler(0, 0, angler);

            //var fireballUp = (GameObject) Instantiate(fireballFourPrefab, up.position- transform.localPosition, transform.rotation= Quaternion.Euler(0, 0, 90)); //= Quaternion.Euler(0, 90, 0));
            GameObject fireballUp = Instantiate(fireballFourPrefab) as GameObject;
            fireballUp.transform.position = up.position;
            Vector3 shootPathu = up.position - spawnPosition;
            fireballUp.transform.position = up.position;
            float angleu = Mathf.Atan2(shootPathu.y, shootPathu.x) * Mathf.Rad2Deg;
            fireballUp.transform.rotation = Quaternion.Euler(0, 0, angleu);

            //var fireballLeft = (GameObject) Instantiate(fireballFourPrefab, left.position- transform.localPosition, transform.rotation= Quaternion.Euler(0, 180, 0)); //= Quaternion.Euler(0, 180, 0));
            GameObject fireballLeft = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathl = left.position - spawnPosition;
            fireballLeft.transform.position =left.position;
            float anglel = Mathf.Atan2(shootPathl.y, shootPathl.x) * Mathf.Rad2Deg;
            fireballLeft.transform.rotation = Quaternion.Euler(0, 0, anglel);
            
           // var fireballDown = (GameObject) Instantiate(fireballFourPrefab, down.position- transform.localPosition, transform.rotation= Quaternion.Euler(0, 0, -90)); //= Quaternion.Euler(0, 270, 0));
            GameObject fireballDown = Instantiate(fireballFourPrefab) as GameObject;
            Vector3 shootPathd = down.position - spawnPosition;
            fireballDown.transform.position = down.position;
            float angled = Mathf.Atan2(shootPathd.y, shootPathd.x) * Mathf.Rad2Deg;
            fireballDown.transform.rotation = Quaternion.Euler(0, 0, angled);
    }
}

