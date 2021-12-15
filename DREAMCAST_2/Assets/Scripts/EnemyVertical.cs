using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : MonoBehaviour
{
    public float WalkSpeed;
    private float _direction;
    private float _startingPosition;
    private float _startScale;
    public float range;
    public float latency;
    private int _time;
    public AnimationClip walk, arms;
    public Animation Legs;
    public Animation Arms;
    private bool _mirror;
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position.y;
        _startScale = transform.localScale.x;
        _direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > latency)
        {
            transform.position = transform.position + new Vector3(0, _direction * WalkSpeed * Time.deltaTime, 0);
            float _distance;
            _distance = transform.position.y - _startingPosition;

            if (_distance > range)
            {
                _direction = -1;
            }
            if (_distance < (range * -1))
            {
                _direction = 1;
            }
        }

        _time++;
    }

    void FixedUpdate()
    {
        //Legs.clip = walk;
       // Legs.Play();
        //Arms.clip = arms;
        //Arms.Play();
    }
}
