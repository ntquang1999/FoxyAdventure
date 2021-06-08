using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    public static AudioClip startSound, stompSound, jumpSound, jumpHSound, powerUpSound, gameOverSound, dieSound, pauseSound, stageClearSound, worldClearSound;
    static AudioSource audiosource;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        startSound = Resources.Load<AudioClip>("Sounds/smb_1-up");
        jumpSound = Resources.Load<AudioClip>("Sounds/smb_jump-small");
        jumpHSound = Resources.Load<AudioClip>("Sounds/smb_jump-super");
        powerUpSound = Resources.Load<AudioClip>("Sounds/smb_powerup");
        gameOverSound = Resources.Load<AudioClip>("Sounds/smb_gameover");
        dieSound = Resources.Load<AudioClip>("Sounds/smb_mariodie");
        pauseSound = Resources.Load<AudioClip>("Sounds/smb_pause");
        stageClearSound = Resources.Load<AudioClip>("Sounds/smb_stage_clear");
        worldClearSound = Resources.Load<AudioClip>("Sounds/smb_world_clear");
        stompSound = Resources.Load<AudioClip>("Sounds/smb_stomp");
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string name)
    {

        switch (name)
        {
            case "start":
                audiosource.PlayOneShot(startSound);
                break;
            case "jump":
                audiosource.PlayOneShot(jumpSound);
                break;
            case "jumpH":
                audiosource.PlayOneShot(jumpHSound);
                break;
            case "power":
                audiosource.PlayOneShot(powerUpSound);
                break;
            case "over":
                audiosource.PlayOneShot(gameOverSound);
                break;
            case "die":
                audiosource.PlayOneShot(dieSound);
                break;
            case "pause":
                audiosource.PlayOneShot(pauseSound);
                break;
            case "stageClr":
                audiosource.PlayOneShot(stageClearSound);
                break;
            case "worldClr":
                audiosource.PlayOneShot(worldClearSound);
                break;
            case "stomp":
                audiosource.PlayOneShot(stompSound);
                break;
        }
    }

    public void adjustVolume(float volume)
    {
        audiosource.volume = volume;
    }

}
