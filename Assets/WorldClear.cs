using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldClear : MonoBehaviour
{
    public float timer = 4;
    private GameMaster gm;
    private save saver;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        saver = GameObject.FindGameObjectWithTag("GM").GetComponent<save>();
        gm.activeStage = "Win";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            saver.deathCount = gm.DeathCounter;
            saver.stage = gm.activeStage;
            saver.SaveFile();
            SceneManager.LoadScene("Menu");
        }
    }
}
