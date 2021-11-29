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
        enemyInRoomListList = enemies.GetEnemyInRoomListList();
        enemyCap = enemies.GetEnemyCap();
        doorList = doors.GetDoorList();
    }
    //Needs to be turned into a function that is checked on update
    void Update()
    {
        for (int i = 0; i < enemyInRoomListList.Count; i++)
        {   
            for (int j = 0; j < enemyInRoomListList[i].Count; j++)
            {   
                if(enemyInRoomListList[i][j] != null){
                    var dest = enemyInRoomListList[i][j].GetComponent<AIDestinationSetter>();
                    if (dest.CanSeePlayer() == true){
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
