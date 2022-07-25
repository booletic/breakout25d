using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 1.5f;
    public AudioClip powerupAC;

    private AudioSource audioSource;
    private Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();
        projectile =
            GameObject.FindWithTag("Projectile").GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(powerupAC);
            projectile.hasPowerup = true;
            Destroy(gameObject);
        }

        // destroy object if out of boundary
        if (other.name == "Sensor")
        {
            Destroy(gameObject);
        }
    }
}
