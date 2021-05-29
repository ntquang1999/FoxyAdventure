using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;        //Public variable to store a reference to the player game object


    private Transform playerTransform;           //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        playerTransform = player.transform;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 temp = transform.position;
        temp.x = playerTransform.position.x;
        if (transform.position.x < temp.x)
        transform.position = temp;

    }
}