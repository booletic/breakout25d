using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public AudioClip blipAC;
    public AudioClip hitAC;
    public AudioClip powerdownAC;
    public AudioClip hurtAC;
    public bool hasPowerup;
    public bool inMotion = false;
    private readonly float boundary = -16.0f;
    private readonly float angularThreshold = 0.1f;
    private Vector3 normalSize = new(0.8f, 0.8f, 1);
    private Vector3 largeSize = new(1.6f, 1.6f, 1);
    private readonly int powerupUpTime = 9;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        hasPowerup = false;
        audioSource = GameObject.Find("Audio Source").GetComponent<AudioSource>();
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

        // if projectile out of boundry
        if (transform.position.y <= boundary)
        {
            audioSource.PlayOneShot(hurtAC);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // if projectile collides with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(hitAC);
            Destroy(collision.gameObject);
        }

        // avoid projectile from parallel bouncing horizontally
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(blipAC);

            if (GetComponent<Rigidbody>().velocity.y <= angularThreshold)
            {
                GetComponent<Rigidbody>().AddForce(
                    Vector3.down, ForceMode.Impulse);
            }
        }

        // if projectile collide with player right-side
        if (collision.gameObject.CompareTag("Right"))
        {
            audioSource.PlayOneShot(blipAC);
            GetComponent<Rigidbody>().AddForce(speed * Vector3.right,
                ForceMode.Impulse);
        }

        // if projectile collide with player left-side
        if (collision.gameObject.CompareTag("Left"))
        {
            audioSource.PlayOneShot(blipAC);
            GetComponent<Rigidbody>().AddForce(speed * Vector3.left,
                ForceMode.Impulse);
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
