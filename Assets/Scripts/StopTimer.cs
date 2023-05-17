using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimer : MonoBehaviour
{
    private GameObject gms;

    // Start is called before the first frame update
    void Start()
    {
        gms = GameObject.Find("GameManager");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            gms.GetComponent<GameManagerScript>().timerOn = false;
            gms.GetComponent<GameManagerScript>().winCanvas.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
