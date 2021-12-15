using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButeleczkaInfo : MonoBehaviour
{
    public static Text text;
    private int pozostalo;
    private int doceloweKropelki;
    // Start is called before the first frame update
    void Start()
    {
        //doceloweKropelki = GameController.__doceloweKropelki;
        Debug.LogWarning(doceloweKropelki);
        text = GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.__doceloweKropelki >= GameController.liczbaKropelek)
        {
            pozostalo = GameController.__doceloweKropelki - GameController.liczbaKropelek;
        }
        else
        {
            pozostalo = 0;
        }
        text.text = GameController.buteleczka.ToString() + "/48 \n \n" + "do zebrania:\n" + pozostalo.ToString();
    }
}
