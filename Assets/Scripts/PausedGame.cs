using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PausedGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseGameScrenn, _player;
    [SerializeField] private static bool GameIsPaused = false;
    [SerializeField] private AudioSource stopBackGroudAudio;
    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
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
                _player.SetActive(true);
                stopBackGroudAudio.Play();
                Restart();
            }            
            else 
            {   
                _player.SetActive(false);
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
    public void SetTimeScaleOfBtn(){
        Time.timeScale = 1f;
    }
   

}
