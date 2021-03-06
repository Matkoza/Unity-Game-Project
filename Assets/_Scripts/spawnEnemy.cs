using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class spawnEnemy : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> spawnRooms, corridorDoors, roomFloor;
    public List<GameObject> doorList;
    [SerializeField]
    public List<GameObject> enemyList;
    public List<List<GameObject>> enemyInRoomListList;
    public List<BoundsInt> roomBoundsList;
    public GameObject enemyPrefab, bombEnemyPrefab;
    public spawnDoors doors;
    [SerializeField]
    public int enemyCap = 10;
    public int deadEnemies, offset;
    void Start()
    {   
        enemyInRoomListList = new List<List<GameObject>>();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        roomBoundsList = roomFirstDungeonGenerator.GetRoomBoundsList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();
        doorList = doors.GetDoorList();
        
        foreach (var room in roomBoundsList){ 
            roomFloor.Clear();
            for (int col = offset; col < room.size.x - offset; col++){
                for (int row = offset; row < room.size.y - offset; row++){
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    if (spawnRooms.Contains(position) && corridorDoors.Contains(position) == false && corridorDoors.Contains(new Vector2Int(position.x - 1, position.y -1)) == false && corridorDoors.Contains(new Vector2Int(position.x + 1, position.y + 1)) == false){
                        roomFloor.Add(position);
                    }
                }
            }

            List<GameObject> enemyList = new List<GameObject>();
            List<GameObject> bombEnemyList = new List<GameObject>();

            for (int i = 0; i < enemyCap; i++)
            {   
                var randomPos = roomFloor[Random.Range(0, roomFloor.Count)];
                var spawnPosition = new Vector3(randomPos.x + 0.5f, randomPos.y + 0.5f, 0);
                var rn = Random.Range(0, 3);
                if(rn == 0){
                    GameObject a = Instantiate(enemyPrefab) as GameObject;
                    a.transform.position = spawnPosition;
                    roomFloor.Remove(randomPos);
                    enemyList.Add(a);
                }
                else{
                    GameObject b = Instantiate(bombEnemyPrefab) as GameObject;
                    b.transform.position = spawnPosition;
                    roomFloor.Remove(randomPos);
                    //enemyList.Add(a);
                }
            }
            enemyInRoomListList.Add(enemyList); 
        }
    }
    public List<List<GameObject>> GetEnemyInRoomListList(){
        return enemyInRoomListList;
    }
    public int GetEnemyCap(){
        return enemyCap;
    }
}

