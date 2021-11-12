using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> spawnRooms;
    public GameObject enemyPrefab;
    public Vector3 spawnPosition;
    public List<Vector2Int> corridorDoors;
    public float radius;

    void Start()
    {   
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        foreach (Vector2Int room in spawnRooms)
        {
            spawnPosition = new Vector3(room.x, room.y, 0);
            if (Random.Range(0,100) <= 0){

                  GameObject a = Instantiate(enemyPrefab) as GameObject;
                  a.transform.position = spawnPosition;
            }
        }
    }
}
