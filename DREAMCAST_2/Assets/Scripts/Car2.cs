using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car2 : MonoBehaviour
{
    public float Speed;
    private Vector3 _startingPosition;
    public AnimationClip wheels;
    public Animation Wheels;

    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(-1 * Speed * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        Wheels.clip = wheels;
        Wheels.Play();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GroundSand")
        {
            transform.position = FindObjectOfType<Car>()._startingPosition;
        }
    }
}
