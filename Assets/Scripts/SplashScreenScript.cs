using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{
    public float StopTimer = 2.5f;
    public bool STimerOn;

    // Start is called before the first frame update
    void Start()
    {
        STimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(STimerOn == true)
        {
            StopTimer -= Time.deltaTime;
        }

        if(StopTimer <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
