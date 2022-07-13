using UnityEngine;

public class Powerup : MonoBehaviour
{
    private AudioSource audioSource;
    private Projectile projectileScript;

    public AudioClip powerupAC;
    public float speed = 1.5f;
    //private readonly float boundary = -16.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();
        projectileScript =
            GameObject.FindWithTag("Projectile").GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;

        //if (transform.position.y <= boundary)
        //{
        //    Destroy(gameObject);
        //}

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(powerupAC);
            projectileScript.hasPowerup = true;
            Destroy(gameObject);
        }

        // destroy object if out of boundary
        if (other.name == "Sensor")
        {
            Destroy(gameObject);
        }
    }
}
