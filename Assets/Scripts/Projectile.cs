using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    //public float coEff = 10.0f;
    public float maxSpeed;

    public AudioClip blipAC;
    public AudioClip powerdownAC;
    public AudioClip hurtAC;

    public bool hasPowerup;
    public bool inMotion = false;

    private readonly int powerupUpTime = 9;

    private Vector3 normalSize = new(0.8f, 0.8f, 1);
    private Vector3 largeSize = new(1.6f, 1.6f, 1);

    private GameManager gameManager;
    public AudioSource AudioSource { get; private set; }
    public Rigidbody ProjectileRb { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;

        gameManager = 
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        AudioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();

        ProjectileRb = GetComponent<Rigidbody>();

        // adjust speed [easy, normal, hard]
        maxSpeed = gameManager.speed;
    }

    // Update is called once per frame
    void Update()
    {
        // after colliding with a powerup
        if (hasPowerup)
        {
            hasPowerup = false;
            StartCoroutine(ScalePowerupRoutine());
        }

        if (ProjectileRb.velocity.magnitude > maxSpeed)
        {
            // limit projectile velocity
            ProjectileRb.velocity =
                Vector3.ClampMagnitude(ProjectileRb.velocity, maxSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // destroy projectile if out of boundary
        if (other.name == "Sensor")
        {
            AudioSource.PlayOneShot(hurtAC);
            Destroy(gameObject);
            gameManager.GameOver();
        }
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        // if projectile collide with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            AudioSource.PlayOneShot(blipAC);
        }
        // if projectile collide with player right-side
        if (collision.gameObject.CompareTag("Right"))
        {
            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.right, ForceMode.Impulse);
        }

        // if projectile collide with player left-side
        if (collision.gameObject.CompareTag("Left"))
        {
            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.left, ForceMode.Impulse);
        }

        // if projectile collide with player mid-side
        if (collision.gameObject.CompareTag("Middle"))
        {
            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.up, ForceMode.Impulse);
        }
    }

    IEnumerator ScalePowerupRoutine()
    {
        // grow projectile temprorary
        transform.localScale = largeSize;
        yield return new WaitForSeconds(powerupUpTime);
        transform.localScale = normalSize;
        AudioSource.PlayOneShot(powerdownAC);
    }

    public bool IsNormSize()
    {
        // check if projectile size
        return transform.localScale == normalSize;
    }
}
