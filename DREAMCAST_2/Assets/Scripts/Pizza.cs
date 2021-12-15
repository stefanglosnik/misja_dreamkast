using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    public Vector2 _inputAxis;
    public float WalkSpeed;
    private float _direction;
    private Vector3 _startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        _direction = 1;
        GetComponent<Rigidbody2D>().isKinematic = true;
        _startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.armed == true)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
        }
        transform.position = transform.position + new Vector3(_direction * WalkSpeed * Time.deltaTime, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Platformy")
        {
            _direction = -1*_direction;
        }

    }

    public void Reset()
    {
        transform.position = _startingPosition;
    }
}
