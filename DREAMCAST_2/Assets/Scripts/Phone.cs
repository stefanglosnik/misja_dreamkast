using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.armed == true)
        {
            if(GameController._numerPoziomu == 1 || GameController._numerPoziomu == 8 || GameController._numerPoziomu == 12)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }

        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
