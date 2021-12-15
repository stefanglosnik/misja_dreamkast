using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextNote : MonoBehaviour
{
    public Text text;
    public string [] polecenia;
    char[] znaki;
    int i = 0;
    private Vector3 _startingPosition;

    private bool _finished = false;
    private bool _zdanieChanged = false;
    private int _zdanie;


    // Start is called before the first frame update
    void Start()
    {
        _startingPosition = gameObject.GetComponent<RectTransform>().localPosition;
        text = gameObject.GetComponent<Text>();
        text.text = "";
        znaki = polecenia[_zdanie].ToCharArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.gameOn == true)
        {
            if (_zdanieChanged == true && _zdanie < polecenia.Length)
            {
                znaki = polecenia[_zdanie].ToCharArray();
                _zdanieChanged = false;
                i = 0;
                text.text += "\n \n";
            }
            if (i % 3 == 0)
            {
                int j = i / 3;
                if (j < znaki.Length)
                {
                    text.text = text.text + znaki[j];
                }
                else
                {
                    //_finished = true;
                    _zdanie++;
                    _zdanieChanged = true;
                }
            }
            i++;
        }
    }

}
