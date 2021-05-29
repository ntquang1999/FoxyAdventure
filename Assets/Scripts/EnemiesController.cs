using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    public CharacterController2D controller;

    public float MoveSpeed = -5f;
    public float PatrolTime = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (PatrolTime >= 0)
        {
            controller.Move(MoveSpeed * Time.fixedDeltaTime, false, false);
            PatrolTime -= Time.fixedDeltaTime;
        }
        else
        {
            PatrolTime = 2f;
            MoveSpeed = -MoveSpeed;
        }
        
    }
}
