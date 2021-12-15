using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    GameObject [] coins;
    private int _score;
    private int _win;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        coins = GameObject.FindGameObjectsWithTag("ObjectCoin");
        if(coins.Length == 0)
        {
            //Application.Quit();
            GameObject.FindObjectOfType<GameOver>().GameIsOver("Win");
        }
    }
}
