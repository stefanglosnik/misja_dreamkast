using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;

    public static AudioManager instance;
    private float _crossfadeTime;
    private float _time = 0.0f;
    private float _timeOfChange;
    private int _loopCounter;
    private float _loopTime;
   
    void Awake()
    {
        //zapobiega odpalaniu się kilku AudioManagerow
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        //DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.reverbZoneMix = s.reverb;
            s.source.panStereo = s.panStereo;
            if (s.mute == true)
            {
                s.source.mute = true;
            }
            else
            {
                s.source.mute = false;
            }
        }
    }

    void Start()
    {
        foreach (Sound s in sounds)
        {
            if (s.isStartingAmbientSound == true)
            {
                Play(s.name);
            }
            if (s.isEmitSoundType == true)
            {
                Play(s.name);
                s.source.loop = true;
            }
        }
    }

    void Update()
    {
        foreach (Sound s in sounds)
        {
            if (s.isEmitSoundType == true)
            {
                if (s.emitSource != null)
                {
                    EmitSound(s.name, s.emitSource);
                }
                else
                {
                    Debug.LogWarning("EmitSound" + s.name + "does not contain an Object that it is emitted by!");
                    Stop(s.name);
                }
            }

            if (s.mute == true)
            {
                s.source.mute = true;
            }
            else
            {
                s.source.mute = false;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound " + name + " not found, my friend!");
        }
    }

    public void PlayOnce(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            if(s.source.isPlaying == false)
            {
                s.source.Play();
            }
        }
        else
        {
            Debug.LogWarning("Sound " + name + " not found, my friend!");
        }
    }

    public void EmitSound(string soundName, GameObject emitSource)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);
        Vector3 elementPosition = emitSource.transform.position;
        Vector3 playerPosition = FindObjectOfType<Player>().transform.position;
        float distance = Vector3.Magnitude(elementPosition - playerPosition);
        float distanceX = elementPosition.x - playerPosition.x;

        //s.source.panStereo = (float)Math.Atan((double)distanceX * 1 / 8);
        s.source.panStereo = 0.05f * distanceX;
        if (s.source.panStereo > 1)
        {
            s.source.panStereo = 1;
        }
        else if(s.source.panStereo < -1)
        {
            s.source.panStereo = -1;
        }

        //float fadeValue = s.volume / (4f * 3.14f * distance * distance * 0.001f);
        float fadeValue = s.volume / (4f * 3.14f * distance * distance * 0.0005f);
        //float fadeValue = 1 - distance / (s.volume * 20);
        //float fadeValue = 1 - distance / (s.volume * 80);
        if (fadeValue < s.volume)
        {
            s.source.volume = fadeValue;
        }
        else
        {
            s.source.volume = s.volume;
        }
    }

    public void AmbientPositionCrossfade(string leftSoundName, string rightSoundName, GameObject environmentObject, float radius)
    {
        Sound leftSound = Array.Find(sounds, sound => sound.name == leftSoundName);
        if (leftSound == null)
        {
            Debug.LogWarning("Sound " + leftSoundName + " was not found!");
        }
        Sound rightSound = Array.Find(sounds, sound => sound.name == rightSoundName);
        if (rightSound == null)
        {
            Debug.LogWarning("Sound " + rightSoundName + " was not found!");
        }
        if(leftSound != null && rightSound != null)
        {
            float environmentObjectPosition = environmentObject.transform.position.x;
            float playerPosition = FindObjectOfType<Player>().transform.position.x;
            float distance = playerPosition - environmentObjectPosition;
            if (distance < -radius)
            {
                rightSound.source.Stop();
            }
            else if (Math.Abs(distance) < radius)
            {
                PlayOnce(rightSoundName);
                PlayOnce(leftSoundName);
                //leftSound.source.volume = leftSound.volume * (1f - (distance + radius) / (2 * radius));
                //rightSound.source.volume = rightSound.volume * ((distance + radius)/ (2 * radius)); 
                leftSound.source.volume = (float)((double)leftSound.volume * Math.Log10((-4.5 / (double)radius) * (double)distance + 5.5));
                rightSound.source.volume = (float)((double)rightSound.volume * Math.Log10((4.5 / (double)radius) * (double)distance + 5.5));

            }
            else if (distance > radius)
            {
                leftSound.source.Stop();
            }
        }
    }
    
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.LogWarning("Sound " + name + " not found, my friend!");
        }
    }

    public void PlayGroundHit(string name, float velocity)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s != null)
        {
            float maxVelocity = 20f;
            if (velocity <= maxVelocity)
            {
                s.source.volume = s.volume * velocity / maxVelocity;
                //s.source.volume = s.volume * velocity * velocity / (2 * maxVelocity);
            }
            else
            {
                s.source.volume = s.volume;
            }

            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Sound " + name + " not found, my friend!");

        }

    }

    public void TimeOfChange(string oldThemeName)
    {   
        if(oldThemeName != null)
        {
            Sound oldTheme = Array.Find(sounds, sound => sound.name == oldThemeName);
            if(oldTheme != null)
            {
                _timeOfChange = oldTheme.source.time;
            }
        }
    }

    public void Crossfade(string oldThemeName, string newThemeName)
    {
        if (oldThemeName != null && newThemeName != null)
        {
            Sound oldTheme = Array.Find(sounds, sound => sound.name == oldThemeName);
            if (oldTheme == null)
            {
                Debug.LogWarning("Theme " + oldThemeName + " was not found!");
            }
            Sound newTheme = Array.Find(sounds, sound => sound.name == newThemeName);
            if (newTheme == null)
            {
                Debug.LogWarning("Theme " + newThemeName + " was not found!");
            }

            if (oldTheme != null && newTheme != null)
            {
                foreach (Sound s in sounds)
                {
                    if (s.name.Contains(oldThemeName))
                    {
                        s.source.loop = false;
                    }
                }
                newTheme.source.loop = true;

                if (oldTheme.source.isPlaying == true && newTheme.source.isPlaying == false)
                {
                    newTheme.source.time = _timeOfChange;
                    newTheme.source.Play();
                    _crossfadeTime = 4 - _timeOfChange;
                    _loopCounter = 0;
                }
                if(newTheme.source.isPlaying == true)
                {
                    if(_loopTime > newTheme.source.time)
                    {
                        _loopCounter = _loopCounter + 1;
                    }
                    _loopTime = newTheme.source.time;
                    
                    if(_loopCounter % 2 == 0)
                    {
                        int _index = _loopCounter / 2;
                        string _layerName = newThemeName + _index;
                        Sound _layer = Array.Find(sounds, sound => sound.name == _layerName);
                        if (_layer != null)
                        {
                            if(_layer.source.isPlaying == false)
                            {
                                _layer.source.loop = true;
                                _layer.source.time = newTheme.source.time;
                                _layer.source.volume = newTheme.volume;
                                _layer.source.Play();
                            }
                        }
                    }

                    if (oldTheme.source.isPlaying == false)
                    {
                        newTheme.source.volume = newTheme.volume;
                        _time = 0;
                    }
                    else
                    {
                        foreach (Sound s in sounds)
                        {
                            if (s.name.Contains(oldThemeName))
                            {
                                //s.source.volume = oldTheme.volume * (1f - _time / _crossfadeTime);
                                s.source.volume = (float)((double)oldTheme.volume * Math.Log10((-9 / (double)_crossfadeTime) * (double)_time + 10));
                            }
                        }
                        //newTheme.source.volume = newTheme.volume * (_time / _crossfadeTime);
                        newTheme.source.volume = (float)((double)newTheme.volume * Math.Log10((9 / (double)_crossfadeTime) * (double)_time + 1));
                        oldTheme.source.pitch = 1f;
                        newTheme.source.pitch = 1f;

                        _time = _time + Time.deltaTime;
                    }
                }

            } 
        }
        else if (oldThemeName == null && newThemeName != null)
        {
            Sound newTheme = Array.Find(sounds, sound => sound.name == newThemeName);
            if (newTheme == null)
            {
                Debug.LogWarning("Theme " + newThemeName + " was not found!");
            }
            else
            {
                newTheme.source.loop = true;

                if (newTheme.source.isPlaying == false)
                {
                    newTheme.source.Play();
                }
                else
                {
                    if (_loopTime > newTheme.source.time)
                    {
                        _loopCounter = _loopCounter + 1;
                    }
                    _loopTime = newTheme.source.time;

                    if (_loopCounter % 2 == 0)
                    {
                        int _index = _loopCounter / 2;
                        string _layerName = newThemeName + _index;
                        Sound _layer = Array.Find(sounds, sound => sound.name == _layerName);
                        if (_layer != null)
                        {
                            if (_layer.source.isPlaying == false)
                            {
                                _layer.source.loop = true;
                                _layer.source.time = newTheme.source.time;
                                _layer.source.Play();
                            }
                        }
                    }
                }
            }
        }
    }

    public void PlayerDeath()
    {
        foreach(Sound s in sounds)
        {
            if(s.isStartingAmbientSound == true)
            {
                //s.source.volume = s.volume;
                //s.source.Play();
            }
        }
    }
}
