using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScriptures : MonoBehaviour
{
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> spawnRooms, corridorDoors, roomFloor;
    public List<GameObject> doorList;
    public List<BoundsInt> roomBoundsList;
    public GameObject scripturePrefab;  
    [SerializeField]
    public int scriptureCap = 2;
    public int offset;
    void Start()
    {   
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        roomBoundsList = roomFirstDungeonGenerator.GetRoomBoundsList();
        //doorList = doors.GetDoorList();
        
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

            List<GameObject> scriptureList = new List<GameObject>();
            for (int i = 0; i < scriptureCap; i++)
            {   
                var randomPos = room.center;
                var spawnPosition = new Vector3(randomPos.x + 0.5f, randomPos.y, 0);
                GameObject a = Instantiate(scripturePrefab) as GameObject;
                a.transform.position = spawnPosition;
                //positionList.Add(a.transform.position);
                scriptureList.Add(a);
                
            }

        }
    }
}
