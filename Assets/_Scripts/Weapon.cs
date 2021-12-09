using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject bulletPrefab;
    public Sprite currentWeaponSprite;

    public float fireRate = 2;
    public int damage = 10;

    public void Shoot(){
        Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, GameObject.Find("WeaponPivot").transform.rotation);  //Quaternion.identity 
    }
}
