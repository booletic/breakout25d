using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float coEff = 10.0f;
    public float maxSpeed = 20.0f;

    public AudioClip blipAC;
    public AudioClip powerdownAC;
    public AudioClip hurtAC;

    public bool hasPowerup;
    public bool inMotion = false;

    private readonly int powerupUpTime = 9;
    private readonly float angularThreshold = 1.0f;

    private Vector3 normalSize = new(0.8f, 0.8f, 1);
    private Vector3 largeSize = new(1.6f, 1.6f, 1);

    private AudioSource audioSource;
    private Rigidbody projectileRb;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;

        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();

        projectileRb = GetComponent<Rigidbody>();
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

        if (projectileRb.velocity.magnitude > maxSpeed)
        {
            projectileRb.velocity =
                Vector3.ClampMagnitude(projectileRb.velocity, maxSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // destroy projectile if out of boundary
        if (other.name == "Sensor")
        {
            audioSource.PlayOneShot(hurtAC);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // avoid projectile from parallel bouncing horizontally
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(blipAC);

            if (projectileRb.velocity.y <= angularThreshold)
            {
                if(transform.position.y <= 0)
                {
                    projectileRb.AddForce(
                        coEff * speed * Time.deltaTime * Vector3.up,
                        ForceMode.Impulse);
                }
                else
                {
                    projectileRb.AddForce(
                        coEff * speed * Time.deltaTime * Vector3.down,
                        ForceMode.Impulse);
                }    
            }
        }

        // if projectile collide with player right-side
        if (collision.gameObject.CompareTag("Right"))
        {
            audioSource.PlayOneShot(blipAC);
            projectileRb.AddForce(speed * Vector3.right, ForceMode.Impulse);
        }

        // if projectile collide with player left-side
        if (collision.gameObject.CompareTag("Left"))
        {
            audioSource.PlayOneShot(blipAC);
            projectileRb.AddForce(speed * Vector3.left, ForceMode.Impulse);
        }

        // if projectile collide with player mid-side
        if (collision.gameObject.CompareTag("Middle"))
        {
            audioSource.PlayOneShot(blipAC);
            projectileRb.AddForce(speed * Vector3.up, ForceMode.Impulse);
        }
    }

    IEnumerator ScalePowerupRoutine()
    {
        // grow projectile temprorary
        transform.localScale = largeSize;
        yield return new WaitForSeconds(powerupUpTime);
        transform.localScale = normalSize;
        audioSource.PlayOneShot(powerdownAC);
    }

    public bool IsNormSize()
    {
        // check if projectile size
        return transform.localScale == normalSize;
    }
}
