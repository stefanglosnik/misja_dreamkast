using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.boostOn && GameController.boostName == "AntMode")
        {
            transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
