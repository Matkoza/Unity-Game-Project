using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnEnemy : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> spawnRooms, corridorDoors, roomFloor;
    public GameObject enemyPrefab;
    //public Vector3 spawnPosition;
    public List<BoundsInt> roomBoundsList;
    public int offset = 0;
    void Start()
    {   
        //everyRoomVector = new List<List<Vector2Int>>();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        roomBoundsList = roomFirstDungeonGenerator.GetRoomBoundsList();
        foreach (var room in roomBoundsList){ 
            roomFloor.Clear();
            for (int col = offset; col < room.size.x - offset; col++)
            {
                for (int row = offset; row < room.size.y - offset; row++)
                {
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    if (spawnRooms.Contains(position)){
                        roomFloor.Add(position);
                    }
                }
            }
            for (int i = 0; i < 5; i++)
            {
                var randomPos = roomFloor[Random.Range(0, roomFloor.Count)];
                var spawnPosition = new Vector3(randomPos.x + 0.5f, randomPos.y + 0.5f, 0);
                GameObject a = Instantiate(enemyPrefab) as GameObject;
                a.transform.position = spawnPosition;
            }
            
           
        }
    }
}

