using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FaketriggerDownWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TilemapCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
