using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private GameMaster gm;
    private save saver;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        saver = GameObject.FindGameObjectWithTag("GM").GetComponent<save>();
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
        Debug.Log("Option...");
    }

    public void quit()
    {

        Application.Quit();
    }

}
