using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "Player")
        {
            GameController.Score(1);
            GameController.Kropelka();
            gameObject.SetActive(false);
            AudioManager.instance.Play("ObjectCoin_Collision");
        }
    }
}
