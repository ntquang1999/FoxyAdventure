using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorEffects : MonoBehaviour
{
    public Foxy foxy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeEffect(string type)
    {
        switch (type)
        {
            case "push_back":
                foxy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10000, 0));
                break;
        }
    }
}
