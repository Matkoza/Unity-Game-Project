using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnWeapons : MonoBehaviour
{
    [SerializeField]
    public RoomFirstDungeonGenerator roomFirstDungeonGenerator;
    public GameObject[] weapons;
    //public GameObject weaponPrefab;
    public Vector3 spawnRoom;
    public Vector2 spawnPos;
    public BoundsInt startRoom;
    void Start()
    {   
        foreach (var weapon in weapons)
        {
            
        
        startRoom = roomFirstDungeonGenerator.GetStartRoom();
        spawnRoom = startRoom.center;
        spawnPos = transform.position = new Vector3(spawnRoom.x + Random.Range(0, 10), spawnRoom.y, 0);
        Instantiate(weapon, spawnPos, Quaternion.identity);
        }
        //GameObject weapon = Instantiate(weaponPrefab) as GameObject;
        //weapon.transform.position = spawnPos;
        //StartCoroutine(SpawnWeapon());
    }
    // IEnumerator SpawnWeapon(){
    //     yield return new WaitForSeconds(2);
    //     Instantiate(weapons[Random.Range(0, weapons.Length)], spawnPos, Quaternion.identity);
    //     StartCoroutine(SpawnWeapon());
    // }
}
