using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZebranePrzedmioty
{
    public GameObject obiekt;
    public bool zajetosc;
    public GameObject slot;
    //public Person(GameObject Obiekt, bool Zajetosc, GameObject Slot)
    //{
    //    obiekt = Obiekt;
    //    zajetosc = Zajetosc;
    //    slot = Slot;
    //}
}

public class Inventory : MonoBehaviour
{
    public GameObject[] sloty = new GameObject[12];
    public static ZebranePrzedmioty[] inventory = new ZebranePrzedmioty[12];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            inventory[i] = new ZebranePrzedmioty();
            inventory[i].obiekt = null;
            inventory[i].zajetosc = false;
            inventory[i].slot = sloty[i];
        }


        if (GameController._numerPoziomu == 6)
        {
            for (int i = 0; i < 12; i++)
            {
                if (inventory[i].zajetosc == true)
                {
                    InventoryPrzechowalnia.obiekty6[i] = inventory[i].obiekt.name;
                }
                else
                {
                    InventoryPrzechowalnia.obiekty6[i] = null;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (InventoryPrzechowalnia.obiekty6[i] != null)
                {
                    inventory[i].zajetosc = true;
                    if (GameObject.Find(InventoryPrzechowalnia.obiekty6[i]) != null)
                    {
                        inventory[i].obiekt = GameObject.Find(InventoryPrzechowalnia.obiekty6[i]);
                        inventory[i].obiekt.transform.position = inventory[i].slot.transform.position;
                        SpriteRenderer spriteRenderer = inventory[i].obiekt.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingLayerName = "UI";
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            }
        }
        else if (GameController._numerPoziomu == 11)
        {
            for (int i = 0; i < 12; i++)
            {
                if (inventory[i].zajetosc == true)
                {
                    InventoryPrzechowalnia.obiekty11[i] = inventory[i].obiekt.name;
                }
                else
                {
                    InventoryPrzechowalnia.obiekty11[i] = null;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (InventoryPrzechowalnia.obiekty11[i] != null)
                {
                    inventory[i].zajetosc = true;
                    if (GameObject.Find(InventoryPrzechowalnia.obiekty11[i]) != null)
                    {
                        inventory[i].obiekt = GameObject.Find(InventoryPrzechowalnia.obiekty11[i]);
                        inventory[i].obiekt.transform.position = inventory[i].slot.transform.position;
                        SpriteRenderer spriteRenderer = inventory[i].obiekt.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingLayerName = "UI";
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            }
        }
        else if (GameController._numerPoziomu == 16)
        {
            for (int i = 0; i < 12; i++)
            {
                if (inventory[i].zajetosc == true)
                {
                    InventoryPrzechowalnia.obiekty16[i] = inventory[i].obiekt.name;
                }
                else
                {
                    InventoryPrzechowalnia.obiekty16[i] = null;
                }
            }
            for (int i = 0; i < 12; i++)
            {
                if (InventoryPrzechowalnia.obiekty16[i] != null)
                {
                    inventory[i].zajetosc = true;
                    if (GameObject.Find(InventoryPrzechowalnia.obiekty16[i]) != null)
                    {
                        inventory[i].obiekt = GameObject.Find(InventoryPrzechowalnia.obiekty16[i]);
                        inventory[i].obiekt.transform.position = inventory[i].slot.transform.position;
                        SpriteRenderer spriteRenderer = inventory[i].obiekt.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingLayerName = "UI";
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 12; i++)
            {
                if (InventoryPrzechowalnia.obiekty[i] != null)
                {
                    inventory[i].zajetosc = true;
                    if (GameObject.Find(InventoryPrzechowalnia.obiekty[i]) != null)
                    {
                        inventory[i].obiekt = GameObject.Find(InventoryPrzechowalnia.obiekty[i]);
                        inventory[i].obiekt.transform.position = inventory[i].slot.transform.position;
                        SpriteRenderer spriteRenderer = inventory[i].obiekt.GetComponent<SpriteRenderer>();
                        spriteRenderer.sortingLayerName = "UI";
                        spriteRenderer.sortingOrder = 1;
                    }
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        //zapisywanie
        for(int i =0; i<12; i++)
        {
            if(inventory[i].zajetosc == true)
            {
                InventoryPrzechowalnia.obiekty[i] = inventory[i].obiekt.name;
            }
            else
            {
                InventoryPrzechowalnia.obiekty[i] = null;
            }
        }
    }

    public static void NewElement(GameObject obiekt)
    {
        int index = 0;


        for (int i = 0; i < 12; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].zajetosc == false)
                {
                    index = i;
                    break;
                }
            }
        }
        SpriteRenderer spriteRenderer = obiekt.GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "UI";
        spriteRenderer.sortingOrder = 1;
        inventory[index].obiekt = obiekt;
        obiekt.transform.position = inventory[index].slot.transform.position;
        inventory[index].zajetosc = true;
    }

    public static bool CheckIfElement(GameObject obiekt)
    {
        bool znaleziono = false;
        ZebranePrzedmioty[] tablica = Inventory.inventory;

        //ZebranePrzedmioty[] tablica = new ZebranePrzedmioty[12];
        //for(int i = 0; i<12; i++)
        //{
        //    tablica[i] = inventory[i];
        //}

        for(int i =0; i<12; i++)
        {
            if (tablica[i] != null)
            {
                if (tablica[i].obiekt == obiekt)
                {
                    znaleziono = true;
                    break;
                }
                else
                {
                    znaleziono = false;
                }
            }
        }
        return znaleziono;
    }

    public static int CheckForElement(GameObject obiekt)
    {
        int index = 0;

        ZebranePrzedmioty[] tablica = new ZebranePrzedmioty[12];
        for (int i = 0; i < 12; i++)
        {
            tablica[i] = inventory[i];
        }

        for (int i = 0; i < 12; i++)
        {
            if (tablica[i].obiekt == obiekt)
            {
                index = i;
                break;
            }
        }
        return index;
    }

    public static void RemoveElement(int i)
    {
            inventory[i].obiekt.transform.localScale = new Vector3(0, 0, 0);
            inventory[i].obiekt = null;
            inventory[i].zajetosc = false;
    }

    public static void LoadCheckpoint(int level)
    {

    }
}
