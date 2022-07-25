using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioClip hitAC;
    public ParticleSystem breakdownParticle;
    private AudioSource audioSource;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();

        gameManager =
            GameObject.Find("Game Manager").GetComponent<GameManager>();
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
        Destroy(gameObject, 0.1f);
    }
}
