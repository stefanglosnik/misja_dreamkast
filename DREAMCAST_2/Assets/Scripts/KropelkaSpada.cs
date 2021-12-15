using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KropelkaSpada : MonoBehaviour
{
    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.name.Contains("Platform"))
        //{
            gameObject.transform.position = startingPosition;
        //}

    }
}
