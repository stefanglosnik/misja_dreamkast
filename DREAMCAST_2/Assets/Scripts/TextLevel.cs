using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLevel : MonoBehaviour
{
    public Text text;
    public string [] powitania;
    char[] znaki;
    int _framecount = 0;
    public GameObject karteczka;
    public GameObject host;
    private Vector3 skala;
    private Vector3 _startingPosition;
    private Vector3 _speakingPosition;
    private bool _finished = false;
    private bool _zdanieChanged = false;
    private int _zdanie;
    private int _stoper = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _startingPosition = gameObject.GetComponent<RectTransform>().localPosition;
        text = gameObject.GetComponent<Text>();
        text.text = "";
        znaki = powitania[_zdanie].ToCharArray();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameController.gameReady && !GameController.gameOn)
        {
            if (Input.GetKeyDown("space"))
            {
                Spacja();

            }
            else
            {
                if (_zdanieChanged == false)
                {
                    if (_framecount % 3 == 0)
                    {
                        int j = _framecount / 3;
                        if (j < znaki.Length)
                        {
                            text.text = text.text + znaki[j];
                        }
                        else
                        {
                            _finished = true;
                            if (_stoper > 8)
                            {
                                _zdanie++;
                                _zdanieChanged = true;
                            }
                            _stoper++;
                        }

                    }
                    _framecount++;
                }
            }
        }



    }

    public void Spacja()
    {
        if (_zdanieChanged == false)
        {
            text.text = powitania[_zdanie];
            _zdanieChanged = true;
            _zdanie++;
        }
        else
        {
            if (_zdanie < powitania.Length)
            {
                znaki = powitania[_zdanie].ToCharArray();
                _zdanieChanged = false;
                _framecount = 0;
                text.text = "";
                _stoper = 0;
            }
            else if (_zdanie == powitania.Length)
            {
                GameController.StartGry();
                _finished = true;
                Destroy(GameObject.Find("Dymek"), 2);
                Destroy(gameObject, 2);
            }
        }
    }

}
