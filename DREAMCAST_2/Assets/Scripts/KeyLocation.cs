using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLocation : MonoBehaviour
{
    public GameObject[] kryjowki;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = kryjowki[Random.Range(0, kryjowki.Length)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
