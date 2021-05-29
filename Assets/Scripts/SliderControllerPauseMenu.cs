using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerPauseMenu : MonoBehaviour
{
    private GameMaster gm;
    public Slider slider;
    public BackgroundMusic music;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        slider.minValue = 0;
        slider.maxValue = 1;
        slider.value = gm.volume;
    }

    public void onValueChange()
    {
        gm.volume = slider.value;
        music.adjustVolume(gm.volume);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
