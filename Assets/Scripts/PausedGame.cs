using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PausedGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameScrenn;
    [SerializeField] private static bool GameIsPaused = false;
    [SerializeField] private AudioSource stopBackGroudAudio;
    void Update()
    {
        turnOnScrenn();
    }
    private void turnOnScrenn()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused) 
            {
                stopBackGroudAudio.Play();
                Restart();
            }            
            else 
            {   
                stopBackGroudAudio.Pause();
                Pause();
            }
        }
    }
    public void Restart()
    {
        pauseGameScrenn.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    public void Pause()
    {
        pauseGameScrenn.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    }
    public void SetTimeScaleOfRestartBtn(){
        Time.timeScale = 1f;
    }
    public void SetTimeScaleOfHomeBtn(){
        Time.timeScale = 1f;
    }
    public void SetTimeScaleOfNextLevel(){
        Time.timeScale = 1f;
    }

}
