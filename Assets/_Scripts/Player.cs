using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
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
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
