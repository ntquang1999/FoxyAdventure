using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallLeft : MonoBehaviour
{
    Vector2 temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        temp.x = Camera.main.transform.position.x - 18.2f;
        transform.position = temp;
    }
}
