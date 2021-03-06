using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    public float timer = 2;
    private GameMaster gm;
    public BackgroundMusic music;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        music.adjustVolume(gm.volume);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        if (timer <= 0)
        {
            gm.DeathCounter--;
            SceneManager.LoadScene(gm.activeStage);
        }
    }
}
