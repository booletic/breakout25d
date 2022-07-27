using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public Transform enemyParent;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        int max = 5;
        int rows = 1;

        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        gameManager.isGameActive = true;

        InvokeRepeating(nameof(SpawnPowerup), 1.0f, Random.Range(10.0f, 20.0f));

        // spawn enemy
        rows = Mathf.Max(1, gameManager.level % max);
        SpawnEnemyRow(enemyPrefab, enemyParent, 4, rows);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyRow(GameObject prefab, Transform parent, int inc, int row)
    {
        int startX = -22;
        int endX = 22;
        int firstRow = 11;

        // number of rows to spawn
        for (int j = firstRow; j > firstRow - (row * 2); j -= 2)
        {
            // number of enemy per row
            for (int i = startX; i <= endX; i += inc)
            {
                Instantiate(prefab, new Vector3(i, j),
                    prefab.transform.rotation).transform.SetParent(parent);
            }
        }
    }

    void SpawnPowerup()
    {
        // only spawn powerup if projectile exist
        GameObject projectile = GameObject.FindWithTag("Projectile");

        if (projectile != null)
        {
            if (projectile.GetComponent<Projectile>().IsNormSize())
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
