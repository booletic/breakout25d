using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float boundry;
    public GameObject projectilePrefab;

    private GameObject projectile;
    private Rigidbody projectileRb;
    private Projectile projectileScript;

    // Start is called before the first frame update
    void Start()
    {
        SpawnProjectile();
    }

    // Update is called once per frame
    void Update()
    {
        // respawn a projectile post destruction
        if (projectile == null)
        {
            SpawnProjectile();
        }

        float projectileSpeed = projectileScript.speed;

        // user-input to move pedal sideways
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(
            horizontalInput * speed * Time.deltaTime * Vector3.right);

        // projectile tracks player
        if (!projectileScript.inMotion)
        {
            projectile.transform.position =
                transform.Find("Projectile Placeholder").position;
        }    

        // limit pedal right movement
        if (transform.position.x > boundry)
        {
            transform.position = new Vector3(
                boundry, transform.position.y);
        }

        // limit pedal left movement
        if (transform.position.x < -boundry)
        {
            transform.position = new Vector3(
                -boundry, transform.position.y);
        }

        // launch projectile on user-input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!projectileScript.inMotion)
            {
                projectileRb.AddForce(
                    new Vector3(
                        Random.Range(-1.0f, 1.01f), 1) * projectileSpeed,
                    ForceMode.Impulse);

                projectileScript.inMotion = true;
            }
        }

        // for testing purpose
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (!projectileScript.inMotion)
            {
                projectileRb.AddForce(
                    new Vector3(
                        1, 0) * projectileSpeed,
                    ForceMode.Impulse);

                projectileScript.inMotion = true;
            }
        }
    }
    void SpawnProjectile()
    {
        projectile = Instantiate(projectilePrefab);
        projectile.transform.position = transform.Find(
                    "Projectile Placeholder").transform.position;
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileScript =
            projectile.GetComponent<Projectile>();
    }
}
