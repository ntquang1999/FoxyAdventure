using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;
    public float MoveSpeed = -5f;
    public float InitialPatrolTime = 2f;
    private float PatrolTime;

    // Start is called before the first frame update
    void Start()
    {
        PatrolTime = InitialPatrolTime;
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
            PatrolTime = InitialPatrolTime;
            MoveSpeed = -MoveSpeed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("dead");
            kill();
        }
    }

    public void kill()
    {
        animator.SetBool("isDead", true);
    }
}
