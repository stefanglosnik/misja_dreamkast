using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilocik : MonoBehaviour
{
    public GameObject zaplata;
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
        GameObject _zaplata = zaplata;
        if (collider.name == "Player")
        {
            bool obecnosc = Inventory.CheckIfElement(_zaplata);
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(_zaplata);
                Inventory.RemoveElement(index);
                GetComponent<Drop>().Dropnelo();
                GameObject.Find("Robocik").GetComponent<Enemy>().enabled = false;
                GameObject.Find("Robocik").GetComponent<PolygonCollider2D>().enabled = false;
            }
        }
    }
}
