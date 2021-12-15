using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePresent : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time: " + GameController.time;
    }
}
