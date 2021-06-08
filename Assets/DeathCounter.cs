using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    public Text counter;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        counter.text = "You died " + -gm.DeathCounter + " times!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
