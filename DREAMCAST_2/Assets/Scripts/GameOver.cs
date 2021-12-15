using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameIsOver(string rezultat)
    {
        if(rezultat == "Win")
        {
            gameObject.GetComponent<Text>().text = "YOU WIN";
        }

        if(rezultat == "Lose")
        {
            gameObject.GetComponent<Text>().text = "GAME OVER";
        }
    }
}
