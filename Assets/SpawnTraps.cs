using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTraps : MonoBehaviour
{
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> spawnRooms, corridorDoors, roomFloor;
    public List<GameObject> doorList;
    public List<List<GameObject>> trapInRoomListList;
    public List<BoundsInt> roomBoundsList;
    public GameObject trapPrefab;
    public int trapCap = 10, offset;
    void Start()
    {
        trapInRoomListList = new List<List<GameObject>>();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        roomBoundsList = roomFirstDungeonGenerator.GetRoomBoundsList();
        
        foreach (var room in roomBoundsList){ 
            roomFloor.Clear();
            for (int col = offset; col < room.size.x - offset; col++){
                for (int row = offset; row < room.size.y - offset; row++){
                    Vector2Int position = (Vector2Int)room.min + new Vector2Int(col, row);
                    if (spawnRooms.Contains(position)){
                        roomFloor.Add(position);
                        //spawnRooms.Remove(position);
                    }
                }
            }

            List<GameObject> trapList = new List<GameObject>();
            for (int i = 0; i < trapCap; i++)
            {   
                var randomPos = roomFloor[Random.Range(0, roomFloor.Count)];
                var spawnPosition = new Vector3(randomPos.x +0.5f, randomPos.y +0.5f, 0);
                GameObject a = Instantiate(trapPrefab) as GameObject;
                a.transform.position = spawnPosition;
                trapList.Add(a);
                
            }

            trapInRoomListList.Add(trapList); 
        }
    }

}
