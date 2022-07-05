using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -18; i <= 18; i += 6)
        {
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 10), enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 7), enemyPrefab.transform.rotation);
            Instantiate(enemyPrefab, new Vector3(i, 0.5f, 4), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
