using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject door;
    private GameObject player;
    public bool resetUOBJ;

    private void Start() 
    {
        //resetUOBJ = false;
        player = GameObject.Find("Player");
    }

    private void Update() 
    {
        if(resetUOBJ == true)
        {
            door.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //Destroy(door); 


        door.GetComponent<BoxCollider2D>().enabled = false;
        door.GetComponent<SpriteRenderer>().enabled = false;

        // player.GetComponent<PlayerScript>().UVisionOBJ[4].GetComponent<BoxCollider2D>().enabled = false;
        // player.GetComponent<PlayerScript>().UVisionOBJ[4].GetComponent<SpriteRenderer>().enabled = false;
        
    }
}
