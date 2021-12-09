using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    //public Weapon currentWeapon;
    private float nextTimeOfFire;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public Vector3 spawnRoom;
    public BoundsInt startRoom;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
        startRoom = roomFirstDungeonGenerator.GetStartRoom();
        spawnRoom = startRoom.center;
        transform.position = new Vector3(spawnRoom.x, spawnRoom.y, 0);
    }
    void Update(){
        // if(Input.GetKeyDown(KeyCode.Q)){
        //     if(Time.time >= nextTimeOfFire){
        //         currentWeapon.Shoot();
        //         nextTimeOfFire = Time.time + 1 / currentWeapon.fireRate;
        //     }
        // }
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
