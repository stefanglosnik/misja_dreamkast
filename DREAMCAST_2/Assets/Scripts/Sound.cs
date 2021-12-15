using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public bool mute;

    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(.1f,3f)]
    public float pitch;

    [Range(.1f, 1f)]
    public float reverb;

    [Range(-1f,1f)]
    public float panStereo;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    
    public bool isEmitSoundType;

    public GameObject emitSource;

    public bool isStartingAmbientSound;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
    }
}
