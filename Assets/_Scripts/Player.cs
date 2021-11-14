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
    public Vector2Int positionGetter, spawnRoom;
    public List<Vector2Int> allRoomCenters;
    public bool spawned = false;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeath(maxHealth);
        allRoomCenters = roomFirstDungeonGenerator.GetRoomCenters();
        spawnRoom = allRoomCenters[Random.Range(0, allRoomCenters.Count - 1)];
        positionGetter = spawnRoom;
        //Debug.Log(positionGetter);
        transform.position = new Vector3(spawnRoom.x, spawnRoom.y, 0);
        spawned = true;
        //positionGetter = new Vector2Int((int)transform.position.x, (int)transform.position.y);
    }
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    public Vector2Int GetPosition(){
       // Debug.Log(positionGetter);
        return positionGetter;
    }
    public bool HasSpawned(){
        return spawned;
    }
}
