using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject howToPlayCanvas;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMainMenu()
    {
        menuCanvas.SetActive(true);
        howToPlayCanvas.SetActive(false);
    }

    public void HowToPlay()
    {
        menuCanvas.SetActive(false);
        howToPlayCanvas.SetActive(true);
    }

    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitButtonPressed()
    {
        Application.Quit();
    }
}
