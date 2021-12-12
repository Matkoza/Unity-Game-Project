using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour
{   
    public GameObject myPlayer;
    public Weapon currentWeapon;
    [SerializeField]
    private Camera cam;
    public GameObject fireballPrefab, fireballFourPrefab;
    public Transform firePoint;
    public Vector3 mousePos;
    private float timeBtwnShots;
    public float startTimeBtwShots;
    private float timeBtwnShotsB;
    public float startTimeBtwShotsB;

    void Start(){
        timeBtwnShots = startTimeBtwShots;
    }
    
    void FixedUpdate(){   
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        Vector3 shootPath = mousePos - transform.position;
        shootPath.Normalize();
        float angle = Mathf.Atan2(shootPath.y, shootPath.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        if (timeBtwnShots <= 0){
            if(Input.GetMouseButton(0)){
                // var fireball = (GameObject) Instantiate(fireballFourPrefab, firePoint.position, transform.rotation);
                // timeBtwnShots = startTimeBtwShots;
                Debug.Log("Shooting weapon");
                currentWeapon.Shoot();
                timeBtwnShots = startTimeBtwShots;
                
            }
            
        }
        else {
            timeBtwnShots -= Time.deltaTime; 
        }
        
        if (timeBtwnShotsB <= 0){
            if (Input.GetMouseButton(1)){
                // var xfireball = (GameObject) Instantiate(fireballPrefab, firePoint.position, transform.rotation);
                // timeBtwnShotsB = startTimeBtwShotsB;
            }
        }
        else {
            //timeBtwnShotsB -= Time.deltaTime;
        }

        // For handling weapon rotation
        if(angle < -90 || angle > 90){
            if(myPlayer.transform.eulerAngles.y == 0){
                transform.localRotation = Quaternion.Euler(180, 0f, -angle);
            }
            else if(myPlayer.transform.eulerAngles.y == 180){
                transform.localRotation = Quaternion.Euler(180, 180, -angle);
            }
       }
    }
}



