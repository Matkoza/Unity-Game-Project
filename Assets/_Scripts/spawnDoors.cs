using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoors : MonoBehaviour
{
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    [SerializeField]
    public TilemapVisualizer tilemapVisualizer;
    [SerializeField]
    public GameObject doorPrefab;
    public List<GameObject> doorList, bossDoorList;
    public Vector3 spawnPosition;
    public List<BoundsInt> roomBounds;
    public BoundsInt endRoom;
    public List<Vector2Int> corridorDoors, roomBoundsPositionList, doorLocations, bossdoorLocations, bossRoomBound;
    void Start()
    {
        doorList = new List<GameObject>();
        roomBounds = roomFirstDungeonGenerator.GetRoomBoundsList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();
        endRoom = roomFirstDungeonGenerator.GetEndRoom();
        SpawnBossDoor(); 
    }
    public void SpawnBossDoor(){

        // Left Bound
        for (int y = endRoom.yMin; y <= endRoom.yMax; y++){
            for (int x = endRoom.xMin; x < endRoom.xMin + 1; x++){
                bossRoomBound.Add(new Vector2Int(x, y));
        	}
        }

        //Upper Bound
        for (int y = endRoom.yMax; y > endRoom.yMax - 1; y --){
            for(int x = endRoom.xMin; x <= endRoom.xMax; x ++){
                bossRoomBound.Add(new Vector2Int(x, y));
            }
        }

        //Right Bound
        for (int y = endRoom.yMax; y >= endRoom.yMin; y --){
            for(int x = endRoom.xMax; x > endRoom.xMax - 1; x --){
                bossRoomBound.Add(new Vector2Int(x, y));
        	}
        }

        //Lower Bound
        for (int y = endRoom.yMin; y < endRoom.yMin + 1; y ++){
            for(int x = endRoom.xMax; x >= endRoom.xMin; x --){
                bossRoomBound.Add(new Vector2Int(x, y));
            }
        }

        foreach (var door in bossRoomBound){
            if(bossdoorLocations.Contains(door) == false){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                var spawnLoc = new Vector3(door.x + 0.5f, door.y + 0.5f, 0);
                bossdoorLocations.Add(new Vector2Int(door.x, door.y));       
                bossDoorList.Add(a);
                a.transform.position = spawnLoc;
            } 
        }
    }
    public void SpawnAllDoors(){
        foreach (BoundsInt roomBound in roomBounds){

                // Left Bound
                for (int y = roomBound.yMin; y <= roomBound.yMax; y++){
                    for (int x = roomBound.xMin; x < roomBound.xMin + 1; x++){
                        roomBoundsPositionList.Add(new Vector2Int(x, y));
                	}
                }

                //Upper Bound
                for (int y = roomBound.yMax; y > roomBound.yMax - 1; y --){
                    for(int x = roomBound.xMin; x <= roomBound.xMax; x ++){
                        roomBoundsPositionList.Add(new Vector2Int(x, y));
                	}
                }

                //Right Bound
                for (int y = roomBound.yMax; y >= roomBound.yMin; y --){
                    for(int x = roomBound.xMax; x > roomBound.xMax - 1; x --){
                        roomBoundsPositionList.Add(new Vector2Int(x, y));
                	}
                }

                //Lower Bound
                for (int y = roomBound.yMin; y < roomBound.yMin + 1; y ++){
                    for(int x = roomBound.xMax; x >= roomBound.xMin; x --){
                        roomBoundsPositionList.Add(new Vector2Int(x, y));
                    }
                }
        }

        foreach (var door in roomBoundsPositionList){
            if(corridorDoors.Contains(door)){
                if(doorLocations.Contains(door) == false){
                    GameObject a = Instantiate(doorPrefab) as GameObject;
                    var spawnLoc = new Vector3(door.x + 0.5f, door.y + 0.5f, 0);
                    doorLocations.Add(new Vector2Int(door.x, door.y));       
                    doorList.Add(a);
                    a.transform.position = spawnLoc;
                }
                
            }
        }
    }
    public List<GameObject> GetDoorList(){
        return doorList;
    }
    public List<GameObject> GetBossDoorList(){
        return bossDoorList;
    }
    
 }
