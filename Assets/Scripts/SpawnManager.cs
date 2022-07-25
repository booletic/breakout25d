using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public Transform enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnPowerup), 1.0f, 5.0f);

        // spawn enemy
        SpawnEnemyRow(enemyPrefab, enemyParent, -22, 22, 4, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyRow(GameObject prefab, Transform parent,
        int start, int end, int inc, int row)
    {
        for (int j = 11; j > 11 - (row * 2); j -= 2)
        {
            for (int i = start; i <= end; i += inc)
            {
                Instantiate(prefab, new Vector3(i, j),
                    prefab.transform.rotation).transform.SetParent(parent);
            }
        }
    }

    void SpawnPowerup()
    {
        GameObject projectile = GameObject.FindWithTag("Projectile");

        if (projectile != null)
        {
            if(projectile.GetComponent<Projectile>().IsNormSize())
            {
                Instantiate(
                    powerupPrefab, new Vector3(
                        Random.Range(
                            -21.0f, 21.0f), 16.0f),
                    powerupPrefab.transform.rotation);
            }
        }
    }

}
