using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableEffects : MonoBehaviour
{
    // Start is called before the first frame update
    public Foxy foxy;
    public CharacterController2D controller;
    public float effectimer = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (effectimer!=0)
        {
            effectimer -= Time.fixedDeltaTime;
            if (effectimer==0)
            {

            }
        }
    }

    public void takeEffect(string itemID)
    {
        switch(itemID)
        {
            case "cherry":
                foxy.runSpeed += 20;
                break;
            case "gem":
                controller.m_JumpForce += 300;
                break;
            case "shroom":
                foxy.runSpeed -= 20;
                break;
        }
    }
    public void endEffect(string itemID)
    {
        switch (itemID)
        {
            case "cherry":
                foxy.runSpeed -= 20;
                break;
            case "gem":
                controller.m_JumpForce -= 300;
                break;
            case "shroom":
                foxy.runSpeed += 20;
                break;
        }
    }

}
