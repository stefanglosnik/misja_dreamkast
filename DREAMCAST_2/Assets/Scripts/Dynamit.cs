using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dynamit : MonoBehaviour
{
    public int time;
    private static int _time;
    private static Text text;
    private static int sekundy;
    private static int minuty;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        _time = time * 50;
        text.text = "00:00";
        sekundy = _time / 50;
        minuty = sekundy / 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameOn)
        {
            _time--;
            sekundy = _time / 50;
            minuty = sekundy / 60;
        }

        if(sekundy % 60 < 10)
        {
            text.text = "0" + minuty.ToString() + ":" + "0" + (sekundy % 60).ToString();
        }
        else
        {
            text.text = "0" + minuty.ToString() + ":" + (sekundy % 60).ToString();
        }
        
        if(_time == 0)
        {
            GameController.GameOver();
        }
    }
}
