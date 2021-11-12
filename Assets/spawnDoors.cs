using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDoors : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    [SerializeField]
    public TilemapVisualizer tilemapVisualizer;
    //public Tilemap wallTilemap;
    [SerializeField]
    //public TileBase floorTile, wallTop, wallSideRight, wallSiderLeft, wallBottom;
    public List<Vector2Int> spawnRooms, leftWalls, rightWalls, upWalls, downWalls, leftCornerWalls, rightCornerWalls;
    public List<BoundsInt> boxBounds;
    public GameObject doorPrefab;
    private int offset = 1;
    public Collider2D[] colliders;
    public Vector3 spawnPosition, spawnPositionB, spawnPositionC;
    public List<BoundsInt> allBoundingAreas;
    public List<Vector2Int> corridorDoors;
    public float radius;
    public int totalNeighbours, leftDoors, rightDoors, downDoors, upDoors, verticalDoors, horizontalDoors, leftCornerDoors, rightCornerDoors;
    void Start()
    {   
       // boxBounds = roomFirstDungeonGenerator.GetBoxBounds();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();
        leftWalls = tilemapVisualizer.GetLeftWalls();
        rightWalls = tilemapVisualizer.GetRightWalls();
        downWalls = tilemapVisualizer.GetDownWalls();
        upWalls = tilemapVisualizer.GetUpWalls();
        leftCornerWalls = tilemapVisualizer.GetLeftCornerWalls();
        rightCornerWalls = tilemapVisualizer.GetRightCornerWalls();

        foreach (var door in corridorDoors) 
        {   
          totalNeighbours = 0;
          verticalDoors = 0;
          horizontalDoors = 0;
          leftDoors = 0;
          rightDoors = 0;
          upDoors = 0;
          downDoors = 0;
          rightCornerDoors = 0;
          leftCornerDoors = 0;


          foreach (var direction in Direction2D.cardinalDirectionsList)
            {   
                var neighbourPosition = door + direction;
                if (leftWalls.Contains(neighbourPosition)) 
                {
                   leftDoors ++;
                }
                else if (leftCornerWalls.Contains(neighbourPosition)){
                    leftCornerDoors ++;
                }
                else if (rightWalls.Contains(neighbourPosition)){
                    rightDoors ++;
                }
                else if (rightCornerWalls.Contains(neighbourPosition)){
                    rightCornerDoors++;
                }
                else if (downWalls.Contains(neighbourPosition))
                {
                    downDoors ++;
                }
                else if (upWalls.Contains(neighbourPosition)){
                    upDoors ++;
                }

            }
            if (leftDoors >= 1 && rightDoors >= 1){
                    GameObject a = Instantiate(doorPrefab) as GameObject;
                    a.transform.position = new Vector3(door.x + 0.5f, door.y - 0.5f, 0);
                }
            else if (leftDoors >= 1 && upDoors >=1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                a.transform.position = new Vector3(door.x + 0.5f, door.y, 0);
            }
            else if (upDoors >= 2){
                    GameObject a = Instantiate(doorPrefab) as GameObject;
                    a.transform.position = new Vector3(door.x + 0.5f, door.y - 0.5f, 0);
            }
    
            else if(upDoors >= 1 && downDoors >= 1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                a.transform.position = new Vector3(door.x + 0.5f, door.y+ 0.5f, 0);
                    
            }
       
        }
    }
}
