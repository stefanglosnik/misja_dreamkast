using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlayer : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //zderzenia z wrogiem
        if (collision.gameObject.tag.StartsWith("Character"))
        {
            if (collision.gameObject.tag.Contains("Enemy") && Player.armed == false)
            {
                GetComponent<Player>().PlayerDeath();
                AudioManager.instance.Play(this.tag + "_Collision");
            }
            if (collision.gameObject.tag.Contains("Enemy") && Player.armed == true)
            {
                AudioManager.instance.Play(collision.gameObject.tag + "_Collision");
                if(collision.gameObject.name == "Kangur")
                {
                    collision.gameObject.GetComponent<Enemy>().knockedOut = true;
                    collision.gameObject.GetComponent<Drop>().Dropnelo();
                    Player.armed = false;
                    GameObject karabin = GameObject.Find("Karabin");
                    if(karabin != null)
                    {
                        karabin.SetActive(false);
                    }
                }
                else if(collision.gameObject.name.Contains("Golebie"))
                {
                    collision.gameObject.GetComponent<Enemy>().knockedOut = true;
                }
                
            }
        }

        //boostery
        if (collision.gameObject.tag.Contains("Booster"))
        {
            GameController.Boost(collision.gameObject.name, true);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.tag.Contains("Obstacle"))
        {
            if (!(GameController.boostOn && GameController.boostName == "AntMode"))
            {
                GetComponent<Player>().PlayerDeath();
                AudioManager.instance.Play(this.tag + "_Collision");
            }

        }

        if (collision.gameObject.tag.Contains("Collectable"))
        {
            Inventory.NewElement(collision.gameObject);
            if(collision.gameObject.name == "Kluczyk")
            {
                BigAssText.WyswietlKomunikatCzasowy("Kluczyk znaleziony!", 2);
            }
        }

        if (collision.gameObject.tag.StartsWith("Object"))
        {
            AudioManager.instance.Play(collision.gameObject.tag + "_Collision");
        }



        //if (collision.gameObject.tag.Contains("Coin"))
        //{
        //    collision.gameObject.SetActive(false);
        //    GameController.Score(1);
        //    GameController.Kropelka();
        //}

        if (collision.gameObject.tag.Contains("Mixture"))
        {
            collision.gameObject.SetActive(false);
            GameController.Score(10);
        }

        if (collision.gameObject.tag.Contains("Weapon"))
        {
            Player.Uzbrojenie(true);
            Destroy(collision.gameObject);            
        }

        if (collision.gameObject.name == ("Drzwi_B"))
        {
            GameController.NextLevel();
        }

        if (collision.gameObject.name == ("OknoEscape"))
        {
            for (int i = 0; i < 12; i++)
            {
                Inventory.RemoveElement(i);
            }
            GameController.NextLevel();
           
        }

        if (collision.gameObject.name == "Szafa")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("Kluczyk"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("Kluczyk"));
                Inventory.RemoveElement(index);
                collision.gameObject.GetComponent<Drop>().Dropnelo();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
               
            }
        }

        if (collision.gameObject.name == "Tadzio")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("Brain"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("Brain"));
                Inventory.RemoveElement(index);
                collision.gameObject.GetComponent<Drop>().Dropnelo();
                collision.gameObject.GetComponent<Enemy>().enabled = false;
                collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                collision.gameObject.GetComponent<Animator>().SetBool("mozg", true);
                BigAssText.WyswietlKomunikatCzasowy("Tadzio odzyskal mozg!", 2);
            }
        }

        if (collision.gameObject.name == "DrzwiSejfu")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("KluczSejf"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("KluczSejf"));
                Inventory.RemoveElement(index);
                Destroy(collision.gameObject);

            }
        }

        if (collision.gameObject.name == "DrzwiSejfu2")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("KluczykA"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("KluczykA"));
                Inventory.RemoveElement(index);
                Destroy(collision.gameObject);

            }
        }

        if (collision.gameObject.name == "DrzwiSejfu3")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("KluczykD"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("KluczykD"));
                Inventory.RemoveElement(index);
                Destroy(collision.gameObject);

            }
        }

        if (collision.gameObject.name == "Dozorca")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("RedApple"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("RedApple"));
                Inventory.RemoveElement(index);
                collision.gameObject.GetComponent<Drop>().Dropnelo();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }


        if (collision.gameObject.name == "Babcia")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("Zegar"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("Zegar"));
                Inventory.RemoveElement(index);
                collision.gameObject.GetComponent<Animator>().SetBool("zegarek", true);
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                BigAssText.WyswietlKomunikatCzasowy("Babcia przyjmuje upominek", 2);
            }
        }

        if (collision.gameObject.name == "Maupka")
        {
            bool obecnosc = Inventory.CheckIfElement(GameObject.Find("Kokos"));
            if (obecnosc)
            {
                int index = Inventory.CheckForElement(GameObject.Find("Kokos"));
                Inventory.RemoveElement(index);
                collision.gameObject.GetComponent<Drop>().Dropnelo();
                collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                BigAssText.WyswietlKomunikatCzasowy("Otrzymujesz wioslo", 2);
            }
        }

        if (collision.gameObject.tag.Contains("Crushable") && GameController.boostOn == true && GameController.boostName == "SuperStrength")
        {
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.name == "Dynamit")
        {
            GameController.GameOver();
        }

        if(collision.gameObject.name == "RedApple")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            collision.gameObject.GetComponent<Rigidbody2D>().freezeRotation = true;
        }

        if(collision.gameObject.name == "Woda")
        {
            GetComponent<Player>().PlayerDeath();
        }

        if(collision.gameObject.name == "Plytka")
        {
            GameObject.Find("Dynamit").SetActive(false);
        }


    }
}
