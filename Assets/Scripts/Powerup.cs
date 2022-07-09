using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip powerupAC;

    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        audioSource.PlayOneShot(powerupAC);
        other.GetComponent<Projectile>().hasPowerup = true;
        Destroy(gameObject);
    }
}
