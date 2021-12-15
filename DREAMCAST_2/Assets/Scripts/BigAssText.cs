using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BigAssText : MonoBehaviour
{
    public static Text text;
    public static bool czasowyKomunikat;

    private static int _time;
    private static int _czasKomunikatu;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        text.text = "";
        _time = 0;
        czasowyKomunikat = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }

        if (czasowyKomunikat == true)
        {
            if(_time > _czasKomunikatu)
            {
                czasowyKomunikat = false;
                _time = 0;
                Clear();
            }
            else
            {
                _time++;
            }
        }
    }

    public static void WyswietlKomunikat(string komunikat)
    {
        text.text = "";
        czasowyKomunikat = false;
        text.text = komunikat;
    }

    public static void WyswietlKomunikatCzasowy(string komunikat, int time)
    {
        Clear();
        text.text = komunikat;
        czasowyKomunikat = true;
        _czasKomunikatu = 50* time;
    }

    public static void Clear()
    {
        czasowyKomunikat = false;
        text.text = "";
    }
}
