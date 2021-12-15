using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dziurka : MonoBehaviour
{
    public GameObject kluczyk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            bool obecnosc = Inventory.CheckIfElement(kluczyk);
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(kluczyk);
                Inventory.RemoveElement(index);
                GameObject.Find("PlatformyZnikajace").SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

}
