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
    //public Player playerPos;
    public GameObject player;
    public Player playerScript;
    public List<Vector2Int> spawnRooms, leftWalls, rightWalls, upWalls, downWalls, leftDownCornerWalls, rightDownCornerWalls, rightUpCornerWalls, leftUpCornerWalls, fullWalls;
    public GameObject doorPrefab;
    public List<GameObject> doorList, doorsToDestroy;
    public Vector3 spawnPosition;
    public List<BoundsInt> roomBounds;
    public BoundsInt markedRoom;
    public List<Vector2Int> corridorDoors, doorPositionList;
    public int totalNeighbours, leftDoors, rightDoors, downDoors, upDoors, verticalDoors, horizontalDoors, leftDownCornerDoors, rightDownCornerDoors, leftUpCornerDoors, rightUpCornerDoors, fullDoors;
    void Start()
    {   
        playerScript = player.GetComponent<Player>();
        doorList = new List<GameObject>();

        roomBounds = roomFirstDungeonGenerator.GetBoxBounds();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();

        leftWalls = tilemapVisualizer.GetLeftWalls();
        rightWalls = tilemapVisualizer.GetRightWalls();
        downWalls = tilemapVisualizer.GetDownWalls();
        upWalls = tilemapVisualizer.GetUpWalls();
        leftDownCornerWalls = tilemapVisualizer.GetLeftDownCornerWalls();
        rightDownCornerWalls = tilemapVisualizer.GetRightDownCornerWalls();
        leftUpCornerWalls = tilemapVisualizer.GetLeftUpCornerWalls();
        rightUpCornerWalls = tilemapVisualizer.GetRightUpCornerWalls();
        fullWalls = tilemapVisualizer.GetFullWalls();

        foreach (var door in corridorDoors){   
            totalNeighbours = 0;
            verticalDoors = 0;
            horizontalDoors = 0;
            leftDoors = 0;
            rightDoors = 0;
            upDoors = 0;
            downDoors = 0;
            rightDownCornerDoors = 0;
            leftDownCornerDoors = 0;
            rightUpCornerDoors = 0;
            leftUpCornerDoors = 0;
            fullDoors = 0;

            foreach (var direction in Direction2D.cardinalDirectionsList)
            {   
                var neighbourPosition = door + direction;
                if (leftWalls.Contains(neighbourPosition)){
                   leftDoors ++;
                }
                else if (rightWalls.Contains(neighbourPosition)){
                    rightDoors ++;
                }
                else if (downWalls.Contains(neighbourPosition)){
                    downDoors ++;
                }
                else if (upWalls.Contains(neighbourPosition)){
                    upDoors ++;
                }
                else if (fullWalls.Contains(neighbourPosition)){
                    fullDoors ++;
                }
                else if (rightDownCornerWalls.Contains(neighbourPosition)){
                    rightDownCornerDoors++;
                }
                else if (leftDownCornerWalls.Contains(neighbourPosition)){
                    leftDownCornerDoors ++;
                }
                else if (rightUpCornerWalls.Contains(neighbourPosition)){
                    rightUpCornerDoors ++;
                }
                else if (leftUpCornerWalls.Contains(neighbourPosition)){
                    leftUpCornerDoors ++;
                }
            }

            if (leftDoors == 1 && rightDoors == 1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                doorList.Add(a);
                a.transform.position = new Vector3(door.x + 0.5f, door.y + 0.5f, 0);
            }
    
            else if(upDoors == 1 && downDoors == 1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                doorList.Add(a);
                a.transform.position = new Vector3(door.x + 0.5f, door.y+ 0.5f, 0);
                    
            }
            else if (fullDoors == 1 && upDoors == 1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                doorList.Add(a);
                a.transform.position = new Vector3(door.x + 0.5f, door.y+ 0.5f, 0);
            }
            else if (upDoors == 1 && leftDownCornerDoors == 1){
                GameObject a = Instantiate(doorPrefab) as GameObject;
                doorList.Add(a);
                a.transform.position = new Vector3(door.x + 0.5f, door.y+ 0.5f, 0);
            }
       
        }

        //Get position of all spawned doors
        foreach (GameObject door in doorList){
            doorPositionList.Add(new Vector2Int((int)door.transform.position.x, (int)door.transform.position.y));
        }
        //Get adjacent doors
        doorsToDestroy.Clear();
        foreach (GameObject door in doorList){
            if (doorPositionList.Contains(new Vector2Int((int)door.transform.position.x, (int)door.transform.position.y + 1)) && doorPositionList.Contains(new Vector2Int((int)door.transform.position.x, (int)door.transform.position.y - 1))){
                doorsToDestroy.Add(door);
            }
            if(doorPositionList.Contains(new Vector2Int((int)door.transform.position.x + 1, (int)door.transform.position.y)) && doorPositionList.Contains(new Vector2Int((int)door.transform.position.x -1, (int)door.transform.position.y))){
                doorsToDestroy.Add(door);
            }
        }
        //Destroy adjacent doors
        foreach (GameObject door in doorsToDestroy){
            Destroy(door);
        }    
        
    }
    public void Update (){
            //Check if player is inside roomBounds
            foreach (BoundsInt roomBound in roomBounds){
                if (playerScript.HasSpawned() == true){
                    //Debug.Log(new Vector3Int((int)playerScript.GetPosition().x, (int)playerScript.GetPosition().y, 0));
                }

                else{

                    Debug.Log("Player hasn't spawned yet");
                }

                if (roomBound.Contains(new Vector3Int((int)playerScript.GetPosition().x, (int)playerScript.GetPosition().y, 0))){
                    markedRoom = roomBound;
                }
            }       
        
        foreach(var point in markedRoom.allPositionsWithin){
            Debug.Log("print please");
        }
    }    
}
