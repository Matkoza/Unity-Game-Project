using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnWeapons : MonoBehaviour
{
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public GameObject[] weapons;
    public Vector3 spawnRoom;
    public Vector2 spawnPos;
    public BoundsInt startRoom;
    void Start(){   
        foreach (var weapon in weapons){
            startRoom = roomFirstDungeonGenerator.GetStartRoom();
            spawnRoom = startRoom.center;
            spawnPos = transform.position = new Vector3(spawnRoom.x + Random.Range(0, 5), spawnRoom.y + Random.Range(0, 5), 0);
            Instantiate(weapon, spawnPos, Quaternion.identity);
        }
    }
}
