using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Foxy : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public CollectableEffects effects;
    private GameMaster gm;
    public CheckPoints firstCheckPoint;
    public InteractorEffects interactor;
    public AudioSource music;
    
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    Queue<string> itemList = new Queue<string>();
    Queue<float> effectTimerList = new Queue<float>();
    public int effectCount = 0;
    public float effectTime = 10f;
    public int maxHP = 1;
    public int currentHP;
    public float deathtimer = -10f;
    public bool isControlled = true;
    public bool isDead = false;

    // Update is called once per frame

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        currentHP = maxHP;
        if (gm.stageComplete) { transform.position = firstCheckPoint.getPosition();gm.stageComplete = false; }
        else transform.position = gm.lastCheckPointPosition;
        gm.activeStage = SceneManager.GetActiveScene().name;
        music.mute = false;
    }


    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove)); 

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
            AudioController.PlaySound("jump");
        }

        if(currentHP<=0)
        {
            animator.SetBool("isDead", true);
            if(deathtimer ==-10f) deathtimer = 2.5f;
            isControlled = false;
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
    }


    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void FixedUpdate()
    {
        if (deathtimer > 0)
        {
            if (isDead == false)
            {
                AudioController.PlaySound("die");
                music.mute = true;
                isDead = true;

            }
            deathtimer -= Time.fixedDeltaTime;
            if (deathtimer <= 0 && currentHP <= 0)
            {
                SceneManager.LoadScene("Dead");
            }
        }
        if (isControlled) 
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        effectCount = itemList.Count;
        for (int i=0;i<effectTimerList.Count;i++)
        {
            float effectTimer = effectTimerList.Dequeue();
            if (effectTimer >= 0)
            {
                effectTimer -= Time.fixedDeltaTime;
                if (effectTimer <= 0)
                {
                    effects.endEffect(itemList.Dequeue());
                }
                else effectTimerList.Enqueue(effectTimer);
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            string effectType = collision.gameObject.GetComponent<CollectableController>().ItemType;
            itemList.Enqueue(effectType);
            effects.takeEffect(effectType);
            effectTimerList.Enqueue(effectTime);
            Destroy(collision.gameObject);
            AudioController.PlaySound("power");
        }
        if (collision.CompareTag("WinPortal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            gm.stageComplete = true;

        }
        if (collision.CompareTag("FakeWall"))
        {
            collision.gameObject.GetComponent<Renderer>().sortingLayerName = "Fake";
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.CompareTag("InvisibleTrigger"))
        {
            collision.gameObject.GetComponent<TilemapCollider2D>().enabled = true;
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        onLanding();
        if (collision.gameObject.tag == "Enemies")
        {
            currentHP--;
        }
        if (collision.gameObject.tag == "MapLethals")
        {
            currentHP--;
        }
        if (collision.gameObject.tag == "Invisible")
        {
            collision.gameObject.GetComponent<Renderer>().sortingLayerName = "Map";
        }

        if (collision.gameObject.tag == "MapInteractors")
        {
            interactor.takeEffect( collision.gameObject.GetComponent<MapInteractors>().name);
        }

        if (collision.gameObject.tag == "InvisibleTrigger")
        {
            collision.gameObject.GetComponent<Renderer>().sortingLayerName = "Map";
        }

    }

}
