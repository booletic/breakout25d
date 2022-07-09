//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerup), 1.0f, 10.0f);
        // spawn enemy
        SpawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 6);
        SpawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 9);
        SpawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemyRow(GameObject prefab, Transform parent, int start, int end, int inc, int row)
    {
        for (int i = start; i <= end; i += inc)
        {
            Instantiate(prefab, new Vector3(i, 0.5f, row),
                prefab.transform.rotation).transform.SetParent(parent);
        }
    
    }

    void SpawnPowerup()
    {
        if(GameObject.FindGameObjectWithTag("Powerup") == null)
        {
            Instantiate(powerupPrefab, new Vector3(
                Random.Range(-21.0f, 21.0f),
                0.5f,
                Random.Range(-4.0f, 4.0f)),
                powerupPrefab.transform.rotation);
        }
    }
}
