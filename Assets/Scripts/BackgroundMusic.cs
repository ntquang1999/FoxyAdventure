using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPause()
    {
        gameObject.GetComponent<AudioSource>().mute = true;
    }
    public void onResume()
    {
        gameObject.GetComponent<AudioSource>().mute = false;
    }
    public void adjustVolume(float volume)
    {
        gameObject.GetComponent<AudioSource>().volume = volume;
    }

}
