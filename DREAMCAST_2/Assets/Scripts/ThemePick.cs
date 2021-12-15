using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemePick : MonoBehaviour
{
    private string _oldThemeName;
    private string _themeName;
    private string _savedOldThemeName;
    private string _savedThemeName;

    void Start()
    {
        
    }

    void Update()
    {
        string groundType = FindObjectOfType<CollisionLeg_0>().groundType;

        AudioManager.instance.Crossfade(_savedOldThemeName, _savedThemeName);

        _oldThemeName = _themeName;
        //if(!String.IsNullOrEmpty(groundType))
        //{
        //    //if(FindObjectOfType<EnemyDetector>().enemiesNearby != 0)
        //    //{
        //    //    if(FindObjectOfType<EnemyDetector>().enemiesNearby == 1)
        //    //    {
        //    //        _themeName = FindObjectOfType<CollisionLeg_0>().groundType + "_ThemeEnemy";
        //    //    }
        //    //    else
        //    //    {
        //    //        _themeName = FindObjectOfType<CollisionLeg_0>().groundType + "_ThemeEnemy_1";
        //    //    }
        //    //}
        //    //else
        //    //{
        //        _themeName = FindObjectOfType<CollisionLeg_0>().groundType + "_Theme";
        //    //}
        //}
        //else
        //{
        //    _themeName = null;
        //}

        _themeName = "Level_" + GameController._numerPoziomu;

        if(_oldThemeName != _themeName)
        {
            _savedOldThemeName = _oldThemeName;
            _savedThemeName = _themeName;
            FindObjectOfType<AudioManager>().TimeOfChange(_oldThemeName);
        }        
    }
}
