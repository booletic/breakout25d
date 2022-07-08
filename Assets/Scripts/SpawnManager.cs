using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        // spawn enemy
        spawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 6);
        spawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 9);
        spawnEnemyRow(enemyPrefab, enemyParent, -21, 21, 6, 12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemyRow(GameObject prefab, Transform parent, int start, int end, int inc, int row)
    {
        for (int i = start; i <= end; i += inc)
        {
            Instantiate(prefab, new Vector3(i, 0.5f, row),
                prefab.transform.rotation).transform.SetParent(parent);
        }
    
    }
}
