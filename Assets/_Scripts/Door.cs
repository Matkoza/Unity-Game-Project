using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{   public Rigidbody2D theRB;
    public Collider2D collider;
    void Start()
    {
        collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = true;
    }
    void Update()
    {
        //collider.enabled;
    }
    private void OnTriggerExit2D(Collider2D other)
    {   
        if (other.tag == "Player"){
            Debug.Log("Entered room");
            //collider.isTrigger = false;   
        }
    }
}
