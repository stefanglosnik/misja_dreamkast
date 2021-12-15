using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetector : MonoBehaviour
{
    GameObject[] Enemies;
    private int _enemiesNearby;
    [HideInInspector]
    public int enemiesNearby;
    public float detectorRange;

    void Start()
    {
        
    }

    void Update()
    {
        Enemies = GameObject.FindGameObjectsWithTag("CharacterEnemy");
        _enemiesNearby = 0;
        foreach (GameObject enemy in Enemies)
        {
            float distance = Math.Abs(enemy.transform.position.x - FindObjectOfType<Player>().transform.position.x);
            if (distance < detectorRange)
            {
                _enemiesNearby = _enemiesNearby + 1;
            }
        }
        enemiesNearby = _enemiesNearby;
    }
}
