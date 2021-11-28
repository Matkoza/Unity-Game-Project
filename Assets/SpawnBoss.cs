using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{   
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public GameObject bossPrefab;
    public Vector3 spawnRoom;
    public BoundsInt endRoom;
    void Start(){
        endRoom = roomFirstDungeonGenerator.GetEndRoom();
        spawnRoom = endRoom.center;
        GameObject a = Instantiate(bossPrefab) as GameObject;
        a.transform.position = new Vector3(spawnRoom.x, spawnRoom.y, 0);
    }
}
