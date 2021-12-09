using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public Weapon weapon;
    private void OnTriggerEnter2D(Collider2D target){
        if(target.tag == "Player"){
            target.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sprite = weapon.currentWeaponSprite;
            target.transform.GetChild(0).GetComponent<Pivot>().currentWeapon = weapon;
            Debug.Log(weapon.currentWeaponSprite == true);
        }
    }
}
