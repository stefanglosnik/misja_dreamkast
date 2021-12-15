using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientPositionCrossfade : MonoBehaviour
{
    public string leftSoundName;
    public string rightSoundName;
    public float radius;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AudioManager.instance.AmbientPositionCrossfade(leftSoundName, rightSoundName, this.gameObject, radius);

    }
}
