using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HandleDoors : MonoBehaviour
{   
    public spawnDoors doors;
    public spawnEnemy enemies;
    public SpawnBoss bosses;
    public List<GameObject> bossList;
    public List<GameObject> doorList, bossDoorList;
    public List<List<GameObject>> enemyInRoomListList;
    public int enemyCap, deadEnemies;
    void Start()
    {
        enemyInRoomListList = enemies.GetEnemyInRoomListList();
        bossList = bosses.GetBossList();
        enemyCap = enemies.GetEnemyCap();
        doorList = doors.GetDoorList();
        bossDoorList = doors.GetBossDoorList();
    }
    void Update()
    {
        UpdateDoorsOnBossRoom();
    }
    public void UpdateDoorsOnBossRoom(){
        foreach (var boss in bossList)
        {
            var dest = boss.GetComponent<AIDestinationSetter>();
            if(dest.CanSeePlayer() == true){
                Debug.Log("Player seen");
                foreach (var bossDoors in bossDoorList)
                {
                    bossDoors.active = true;
                }
            }
        } 
    }
    public void UpdateDoorsOnEnemyRooms(){
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
