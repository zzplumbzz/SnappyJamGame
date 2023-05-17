using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    
    public float timer;
    public bool timerOn;
    public TMP_Text timerTXT;
    public TMP_Text endTimeTXT;
    public GameObject winCanvas;
    public GameObject pauseCanvas;
    public bool pauseTrue;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        timerOn = true;
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        pauseTrue = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timerTXT.SetText(string.Format("{0:0.00}", timer.ToString()));
        endTimeTXT.SetText(timer.ToString() + "Seconds");

        if(timerOn == true)
        {
            timer += Time.deltaTime;
        }

        if(pauseTrue == false && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseTrue = true;
            pauseCanvas.SetActive(true);
            Time.timeScale = 0;
        }
        else if(pauseTrue == true && Input.GetKeyDown(KeyCode.Escape))
        {
            pauseTrue = false;
            pauseCanvas.SetActive(false);
            Time.timeScale = 1;
        }
    }

  
    public void ResumeButtonPressed()
    {
        pauseCanvas.SetActive(false);
        pauseTrue = false;
        Time.timeScale = 1;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
