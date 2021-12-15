using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float WalkSpeed;
    private static float _walkSpeed;
    private float _direction;
    private Vector3 _startingPosition;
    private float _startScale;
    public float range;
    public Animator animator;
    public AnimationClip walk, arms;
    public Animation Legs;
    public Animation Arms;
    private bool _mirror;
    public float latency;
    private int _time;
    public bool knockedOut;

    private SpriteRenderer _sprite;
    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = transform.position;
        _startScale = transform.localScale.x;
        _direction = 1;
        //GameObject.Find(this.name + "Drop").transform.localScale = new Vector3(0, 0, 0);
        if(animator != null)
        {
            animator.SetBool("knockedOut", false);
        }
        _walkSpeed = WalkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (knockedOut == false)
        {
            if (_time > latency)
            {
                transform.position = transform.position + new Vector3(_direction * _walkSpeed * Time.deltaTime, 0);
                float _distance;
                _distance = transform.position.x - _startingPosition.x;
                if (_distance > range)
                {
                    _direction = -1;
                }
                if (_distance < (range * -1))
                {
                    _direction = 1;
                }

                if (_direction == -1f)
                {
                    _mirror = true;
                }
                else
                {
                    _mirror = false;
                }
            }
            _time++;
        }
        else
        {
            Nokaut();
        }
    }

    void FixedUpdate()
    {
        if (_mirror == true)
        {
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
        }
        else
        {
            transform.localScale = new Vector3(_startScale, _startScale, 1);
        }
        //Legs.clip = walk;
         // Legs.Play();
         //Arms.clip = arms;
         //Arms.Play();
    }

    public void Nokaut()
    {
        if (gameObject.name == "Kangur")
        {
            animator.SetBool("knockedOut", true);
            GetComponent<CapsuleCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }

        //GameObject.Find(this.name + "Drop").transform.localScale = new Vector3(1f, 1f, 1f);
        knockedOut = false;
    }

    public static void Stop()
    {
        _walkSpeed = 0;
    }
    //public void Resurrection()
    //{
    //    transform.position = new Vector3(_startingPosition.x, _startingPosition.y, 0);
    //    knockedOut = false;
    //}
}
