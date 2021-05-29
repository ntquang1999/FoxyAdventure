using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPause = false;
    public GameObject pauseMenu;
    public GameObject optionMenu;
    private GameMaster gm;
    private save saver;
    public BackgroundMusic music;
    public AudioController audios;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        saver = GameObject.FindGameObjectWithTag("GM").GetComponent<save>();
    }

    // Update is called once per frame
    void Update()
    {
        music.adjustVolume(gm.volume);
        audios.adjustVolume(gm.volume); 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                ResumeGame();
            } else
            {
                PauseGame();
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            music.adjustVolume(gm.volume += 0.1f);
            audios.adjustVolume(gm.volume);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            music.adjustVolume(gm.volume -= 0.1f);
            audios.adjustVolume(gm.volume);
        }

    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        music.onPause();
        Time.timeScale = 0;
        GameIsPause = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        optionMenu.SetActive(false);
        music.onResume();
        Time.timeScale = 1;
        GameIsPause = false;
    }


    public void Menu()
    {
        gm.stageComplete = true;
        saver.deathCount = gm.DeathCounter;
        saver.stage = gm.activeStage;
        saver.volume = gm.volume;
        saver.SaveFile();
        GameIsPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
