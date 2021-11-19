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
    public List<GameObject> doorList;
    public Vector3 spawnPosition;
    public List<BoundsInt> roomBounds;
    public List<Vector2Int> corridorDoors, roomBoundsPositionList;
    void Start()
    {
        doorList = new List<GameObject>();
        roomBounds = roomFirstDungeonGenerator.GetRoomBoundsList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();

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
                GameObject a = Instantiate(doorPrefab) as GameObject;
                a.transform.position = new Vector3(door.x + 0.5f, door.y + 0.5f, 0);
                doorList.Add(a);
            }
        }
    }
 }
