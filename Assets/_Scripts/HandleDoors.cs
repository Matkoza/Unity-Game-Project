using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HandleDoors : MonoBehaviour
{   
    public Transform player;
    public spawnDoors doors;
    public spawnEnemy enemies;
    public List<GameObject> doorList;
    public List<List<GameObject>> enemyInRoomListList;
    public int enemyCap, deadEnemies;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        doorList = doors.GetDoorList();
        enemyInRoomListList = enemies.GetEnemyInRoomListList();
        enemyCap = enemies.GetEnemyCap();
        Debug.Log(enemyInRoomListList.Count);
        
    }

    void Update()
    {
        for (int i = 0; i < enemyInRoomListList.Count; i++)
        {   
            for (int j = 0; j < enemyInRoomListList[i].Count; j++)
            {   
                if(enemyInRoomListList[i][j] != null){
                    var dest = enemyInRoomListList[i][j].GetComponent<AIDestinationSetter>();
                    //Debug.Log(dest.sees);
                    if (dest.sees == true){
                        //Debug.Log("Player seen ");
                        foreach (var door in doorList){
                            door.active = true;
                        }
                    }
                }   
                
                else if(enemyInRoomListList[i][j] == null){
                    Debug.Log("Enemy Died ");
                    deadEnemies ++;
                    Debug.Log("Total dead enemies in room " + deadEnemies);
                    enemyInRoomListList[i].Remove(enemyInRoomListList[i][j]);
                }
                
                if(deadEnemies == enemyCap){
                    Debug.Log("Room Cleared ");
                    deadEnemies = 0;
                    foreach (var door in doorList)
                    {   
                        Debug.Log("Door deactivated ");
                        door.active = false;
                    }
                }        
            }
        }
    }
}
