using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class PutPlayerAtStart : MonoBehaviour
{  [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public List<Vector2Int> allRoomCenters;
    public Vector2Int spawnRoom;


    void Start()
    {   
        allRoomCenters = roomFirstDungeonGenerator.GetRoomCenters();
        spawnRoom = allRoomCenters[Random.Range(0, allRoomCenters.Count - 1)];
        transform.position = new Vector3(spawnRoom.x, spawnRoom.y, 0);
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
