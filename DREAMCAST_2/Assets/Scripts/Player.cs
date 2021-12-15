using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {
    //parametry
    public float WalkSpeed;
    public static float walkSpeed;
    public float JumpForce;
    public static float jumpForce;

    //animacje
    public Animator animator;

    //basics
    public Transform _GroundCast;
    public Camera cam;
    [HideInInspector]
    public bool mirror;


    [HideInInspector]
    public static bool armed;



    //[HideInInspector]
    public bool _canJump, _canWalk;
    //[HideInInspector]
    public bool _isWalk, _isJump;
    private float rot, _startScale;
    private Vector3 _startPosition;
    [HideInInspector]
    public Rigidbody2D rig;
    [HideInInspector]
    public Vector2 _inputAxis;
    private RaycastHit2D _hit;

	void Start ()
    {
        walkSpeed = WalkSpeed;
        rig = gameObject.GetComponent<Rigidbody2D>();
        _startScale = transform.localScale.x;
        if(GameController._numerPoziomu == 6)
        {
            _startPosition = new Vector3(-23f, -15f, 0);
            
        }
        else
        {
            _startPosition = transform.position;
        }

        armed = false;

        jumpForce = JumpForce;
	}

    void Update()
    {
        WalkSpeed = walkSpeed;
        if (GameController.gameOn == true)
        {

            //if (_hit = Physics2D.Linecast(new Vector2(_GroundCast.position.x, _GroundCast.position.y + 0.1f), _GroundCast.position))
            if(CollisionLeg_0.stoiMi)
            {
                //if (!_hit.transform.CompareTag("Player"))
                //{
                    _canJump = true;
                    _canWalk = true;
                //}
            }
            else _canJump = false;

            _inputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if ((_inputAxis.y > 0 || Input.GetKeyDown("space")==true) && _canJump)
            {
                _canWalk = false;
                _isJump = true;
            }


            if (rig.velocity.x < 0)
            {
                mirror = true;
            }
            else
            {
                mirror = false;
            }

            if (transform.position.y < -70)
            {
                PlayerDeath();
            }
        }
    }

    void FixedUpdate()
    {
        //Vector3 dir = cam.ScreenToWorldPoint(Input.mousePosition) - _Blade.transform.position;
        //dir.Normalize();

        if (!mirror)
        {
            //rot = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(_startScale, _startScale, 1);
            //_Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
        if (mirror)
        {
            //rot = Mathf.Atan2(-dir.y, -dir.x) * Mathf.Rad2Deg;
            transform.localScale = new Vector3(-_startScale, _startScale, 1);
            //_Blade.transform.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }

        if (_inputAxis.x != 0)
        {
            rig.velocity = new Vector2(_inputAxis.x * WalkSpeed * Time.deltaTime, rig.velocity.y);

            if (_canWalk)
            {
                animator.SetBool("isWalking", true);
            }

        }
        else if (GuzikPrawo.prawo == true && GameController.gameOn == true)
        {
            rig.velocity = new Vector2(1f * WalkSpeed * Time.deltaTime, rig.velocity.y);

            if (_canWalk)
            {
                animator.SetBool("isWalking", true);
            }

        }
        else if (GuzikLewo.lewo == true && GameController.gameOn == true)
        {
            rig.velocity = new Vector2(-1f * WalkSpeed * Time.deltaTime, rig.velocity.y);

            if (_canWalk)
            {
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
            animator.SetBool("isWalking", false);
        }



        if (_isJump)
        {
            rig.AddForce(new Vector2(0, jumpForce));
            _canJump = false;
            _isJump = false;
        }
    }

    public void SkokSmall()
    {
        if (_canJump)
        {
            _canWalk = false;
            _isJump = true;
        }
    }

    public void SkokBig()
    {
        if (_canJump)
        {
            _canWalk = false;
            _canJump = false;
            rig.AddForce(new Vector2(0, 6000f));
        }
    }

    public bool IsMirror()
    {
        return mirror;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, _GroundCast.position);
    }

    public void PlayerDeath()
    {
        transform.position = _startPosition;
        AudioManager.instance.PlayerDeath();
        GameController.Death();
        GameObject pizza = GameObject.Find("Pizza");
        if(pizza != null)
        {
            pizza.GetComponent<Pizza>().Reset();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag == "GroundStreet2")
        {
            JumpForce = 1500;
        }
        else
        {
            JumpForce = 800;
        }*/
    }

    public static void Uzbrojenie(bool uzbrojony)
    {
        if(uzbrojony == true)
        {
            armed = true;
        }
        if(uzbrojony == false)
        {
            armed = false;
        }
    }

    public void Lewo()
    {
        rig.velocity = new Vector2(-1f * WalkSpeed * Time.deltaTime, rig.velocity.y);
    }

    public void Prawo()
    {
        rig.velocity = new Vector2(1f * WalkSpeed * Time.deltaTime, rig.velocity.y);
    }
}
