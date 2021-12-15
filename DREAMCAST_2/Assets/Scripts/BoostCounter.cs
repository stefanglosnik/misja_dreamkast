using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostCounter : MonoBehaviour
{
    public static Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void BoostOn(string name, int czas)
    {
        int sekundy = czas / 50;
        text.text = name + ": " + sekundy.ToString();
    }

    public static void BoostOff()
    {
        text.text = "";
    }
}
