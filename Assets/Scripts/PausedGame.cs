using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PausedGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameScrenn;
    [SerializeField] private static bool GameIsPaused = false;
    void Update()
    {
        turnOnScrenn();
    }
    private void turnOnScrenn()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (GameIsPaused) Restart();            
            else Pause();
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
    public void SetTimeScalexOfHomeBtn(){
        Time.timeScale = 1f;
    }

}
