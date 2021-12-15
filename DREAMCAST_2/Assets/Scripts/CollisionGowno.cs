using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionGowno : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.StartsWith("Object"))
        {
            AudioManager.instance.Play(collision.gameObject.tag + "_Collision");
        }
    }
}
