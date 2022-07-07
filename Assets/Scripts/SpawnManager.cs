using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int gapX = 6;
    public int gapZ = 3;
    // Start is called before the first frame update
    void Start()
    {
        // spawn enemy
        for (int i = -21; i <= 21; i += gapX)
        {
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 6), enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 6 + gapZ), enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 6 + gapZ * 2), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
