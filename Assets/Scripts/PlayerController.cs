using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float boundry;
    public GameObject projectilePrefab;
    public GameObject projectileCrazyPrefab;

    //private int score;
    //public TextMeshProUGUI scoreText;

    private GameObject projectile;
    private Rigidbody projectileRb;
    private Projectile projectileScript;

    // Start is called before the first frame update
    void Start()
    {
        var temp = SpawnProjectile();
        GameObject.Find("Start Text").GetComponent<TextMeshProUGUI>().text = "press < space > to start\n" + temp;
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
            GameObject.Find("Start Text").SetActive(false);

            if (!projectileScript.inMotion)
            {
                projectileRb.AddForce(
                    new Vector3(
                        Random.Range(-1.0f, 1.01f), 1) * projectileSpeed,
                    ForceMode.Impulse);

                projectileScript.inMotion = true;
            }
        }

        // for testing: launch projectile 90 degree
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

    string SpawnProjectile()
    {
        // instantiate a projectile and place it in the placeholder
        float temp = Random.Range(0.0f, 1.0f);

        if (temp < 0.5f)
        {
            projectile = Instantiate(projectilePrefab);
        }
        else
        {
            projectile = Instantiate(projectileCrazyPrefab);
        }
        
        projectile.transform.position =
            transform.Find("Projectile Placeholder").transform.position;
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileScript =
            projectile.GetComponent<Projectile>();

        if (projectile.name.Contains("Crazy"))
            return "you got a crazy projectile";
        else
            return "you got a normal projectile";
    }
}
