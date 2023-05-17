using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneScript : MonoBehaviour
{
    private GameObject player;
    public Transform spawnPointTest;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public bool SP2A;
    public Transform spawnPoint3;
    public bool SP3A;
    public Transform spawnPoint4;
    public bool SP4A;
    //public SwitchScript ss;
    

    private void Start() {
        player = GameObject.Find("Player");

        SP2A = false;
        SP3A = false;
        SP4A = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            //ss.resetUOBJ = true;
            //SceneManager.LoadScene("GameScene");

            

            if(SP2A == true)
            {
                player.transform.position = spawnPoint2.transform.position;
            }
            else if (SP3A == true)
            {
                player.transform.position = spawnPoint3.transform.position;
            }
            else if (SP4A == true)
            {
                player.transform.position = spawnPoint4.transform.position;
            }
            else
            {
                player.transform.position = spawnPoint1.transform.position;
            }
            
        }
    }
}
