using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip hitAC;
    public ParticleSystem breakdownParticle;
    private AudioSource audioSource;
    private GameManager gameManager;

    private int lives;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();

        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();

        lives = (int)(Mathf.Log(gameManager.level) + 1);
        //Debug.Log(lives);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // if projectile collides with enemy
        audioSource.PlayOneShot(hitAC);
        Instantiate(breakdownParticle, transform.position, transform.rotation);
        gameManager.UpdateScore();

        if (lives <= 1)
        {
            Destroy(gameObject, 0.1f);
        }
        else
        {
            lives--;
            GetComponent<Renderer>().material.color *= 0.7f;
        }
    }
}
