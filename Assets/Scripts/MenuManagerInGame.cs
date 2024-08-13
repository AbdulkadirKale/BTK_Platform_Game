using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{

    public GameObject inGameScreen, pauseScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        inGameScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void RePlayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(1);
    }
}
