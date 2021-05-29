using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private GameMaster gm;
    private save saver;
    public Slider slider;
    public BackgroundMusic music;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        saver = GameObject.FindGameObjectWithTag("GM").GetComponent<save>();
        saver.LoadFile();
        gm.volume = saver.volume;
        music.adjustVolume(gm.volume);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void newGame()
    {
        gm.stageComplete = true;
        gm.DeathCounter = 0;
        SceneManager.LoadScene("Stage-1");
    }

    public void continueGame()
    {
        saver.LoadFile();
        gm.stageComplete = true;
        gm.DeathCounter = saver.deathCount;
        SceneManager.LoadScene(saver.stage);
    }

    public void options()
    {
        saver.LoadFile();
        gm.volume = saver.volume;
    }

    public void quit()
    {
        Application.Quit();
    }
    public void back()
    {
        saver.volume = slider.value;
        saver.SaveFile();
        music.adjustVolume(gm.volume);
    }

}
