using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLeg_0 : MonoBehaviour
{
    [HideInInspector]
    public string groundType;
    public static bool stoiMi;

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Ground"))
        {
            float velocity = collision.relativeVelocity.y;

            if (collision.gameObject.tag.Contains("Cave"))
            {
                if(velocity > 5f)
                {
                    AudioManager.instance.PlayGroundHit(collision.gameObject.tag + "_Landing", velocity);
                }
            }
            else
            {
                AudioManager.instance.PlayGroundHit(collision.gameObject.tag + "_Landing", velocity);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Ground") || collision.gameObject.tag.StartsWith("Object"))
        {
            AudioManager.instance.Stop(collision.gameObject.tag + "_Walk");
        }

        if(FindObjectOfType<Player>()._inputAxis.y > 0)
        {
            AudioManager.instance.Play(this.tag + "_Jump");
        }

        stoiMi = false;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.StartsWith("Ground") || collision.gameObject.tag.StartsWith("Object"))
        {
            if (FindObjectOfType<Player>()._inputAxis.x != 0)
            {
                AudioManager.instance.PlayOnce(collision.gameObject.tag + "_Walk");
            }
            else
            {
                AudioManager.instance.Stop(collision.gameObject.tag + "_Walk");
            }
        }
        groundType = collision.gameObject.tag;
        stoiMi = true;
    }
}