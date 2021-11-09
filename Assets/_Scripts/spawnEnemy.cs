using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{   
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> allRoomCenters;
    public List<Vector2Int> spawnRooms;
    public List<BoundsInt> boxBounds;
    public GameObject enemyPrefab;
    private int offset = 1;
    public Collider2D[] colliders;
    public Vector3 spawnPosition, spawnPositionB, spawnPositionC;
    public List<BoundsInt> allBoundingAreas;
    public List<Vector2Int> corridorDoors;
    public bool canSpawn = false;
    int preventLoops;
    public float radius;
    void Start()
    {   
        allRoomCenters = roomFirstDungeonGenerator.GetRoomCenters();
        boxBounds = roomFirstDungeonGenerator.GetBoxBounds();
        spawnRooms = roomFirstDungeonGenerator.GetAllSpawnList();
        corridorDoors = roomFirstDungeonGenerator.GetCorrodorDoors();
        foreach (Vector2Int door in corridorDoors)
        {
            
        }
      //  foreach (var box in boxBounds){
       //   for (int i = 0; i <= box.size.x; i++)
        //  {   
         //   Vector2Int spawnPosition = (Vector2Int)box.min + new Vector2Int(i, 0);
         //   Vector2Int spawnPosition2 = (Vector2Int)box.max + new Vector2Int(i, 0);
         //   GameObject a = Instantiate(enemyPrefab) as GameObject;
         //   a.transform.position = new Vector3(spawnPosition.x, spawnPosition.y,0);
          //  GameObject b = Instantiate(enemyPrefab) as GameObject;
         //   b.transform.position = new Vector3(spawnPosition2.x, spawnPosition2.y,0);
         // }
          
        //}
        foreach (Vector2Int room in spawnRooms)
        {
            spawnPosition = new Vector3(room.x, room.y, 0);
           // spawnPositionB = new Vector3(room.x, room.y, 0);
           // spawnPositionC = new Vector3(room.x, room.y, 0);
            if (Random.Range(0,100) <= 0){

                  GameObject a = Instantiate(enemyPrefab) as GameObject;
                  a.transform.position = spawnPosition;
                
                
               // GameObject b = Instantiate(enemyPrefab) as GameObject;
              //  b.transform.position = spawnPositionB;
               // GameObject c = Instantiate(enemyPrefab) as GameObject;
               // c.transform.position = spawnPositionC;
            }
        }
    }
       // foreach (Vector2Int center in allRoomCenters)
       // {   
               // while(!canSpawn){
              //      spawnPosition = new Vector3(center.x + Random.Range(-3f, 3f), center.y + Random.Range(-3f, 3f), 0);
              //      spawnPositionB = new Vector3(center.x + Random.Range(-3f, 3f), center.y + Random.Range(-3f, 3f), 0);
              //      spawnPositionC = new Vector3(center.x + Random.Range(-3f, 3f), center.y + Random.Range(-3f, 3f), 0);
             //       canSpawn = PreventOverlap(spawnPosition);
            //        if (wallBounds.Contains(Vector3Int.FloorToInt(spawnPosition)) | wallBounds.Contains(Vector3Int.FloorToInt(spawnPositionB)) | wallBounds.Contains(Vector3Int.FloorToInt(spawnPositionC))){
             //           canSpawn = false;
             //       }

             //       else {
             //           canSpawn = true;
            //        }
//
                   // if(canSpawn){
           //             break;
      //              }
//
  //                  preventLoops++;
//
  //                  if(preventLoops > 100){
    //                    Debug.Log("Too many attempts");
      //                  break;
        //            }
          //      }
            //    GameObject a = Instantiate(enemyPrefab) as GameObject;
              //  a.transform.position = spawnPosition;
                //GameObject b = Instantiate(enemyPrefab) as GameObject;
                //b.transform.position = spawnPositionB;
                //GameObject c = Instantiate(enemyPrefab) as GameObject;
                //c.transform.position = spawnPositionC;
        //}
    //}
    bool PreventOverlap(Vector3 spawnPosition){
        colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        if (colliders == null){
            return true;
        }
        else {
            return false;
        }
    }
    void Update()
    {
        
    }
}
