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
        SpawnEnemyRow(enemyPrefab, enemyParent, -22, 22, 4, 12);
        SpawnEnemyRow(enemyPrefab, enemyParent, -22, 22, 4, 10);
        SpawnEnemyRow(enemyPrefab, enemyParent, -22, 22, 4, 8);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyRow(GameObject prefab, Transform parent,
        int start, int end, int inc, int row)
    {
        for (int i = start; i <= end; i += inc)
        {
            Instantiate(prefab, new Vector3(i, 0.5f, row),
                prefab.transform.rotation).transform.SetParent(parent);
        }
    }

    void SpawnPowerup()
    {
        bool isNormSize = GameObject.FindWithTag(
            "Projectile").GetComponent<Projectile>().IsNormSize();

        if (GameObject.FindGameObjectWithTag("Powerup") == null && isNormSize)
        {
            Instantiate(
                powerupPrefab, new Vector3(
                    Random.Range(
                        -21.0f, 21.0f), 0.5f, 16.0f),
                powerupPrefab.transform.rotation);
        }
    }

}
