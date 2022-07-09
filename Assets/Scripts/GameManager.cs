using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    public bool projectileInMotion;
    public AudioClip hurtAC;

    private GameObject projectile;
    private Rigidbody projectileRb;
    private Projectile projectileScript;
    private AudioSource audioSource;


    void Start()
    {
        projectileInMotion = false;
        Instantiate(projectilePrefab);
        projectile = GameObject.FindWithTag("Projectile");
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileScript = projectile.GetComponent<Projectile>();
        audioSource =
            GameObject.Find("Audio Source").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // projectile tracks player
        if (!projectileInMotion)
        {
            projectile.transform.position = player.transform.Find(
                "Projectile Placeholder").transform.position;
        }

        // reset projectile if out of boundy
        if (projectile.transform.position.z < -20)
        {
            audioSource.PlayOneShot(hurtAC);

            // reset to default size if projectile growth powerup is active
            projectileScript.hasPowerup = false;
            projectile.transform.localScale = new Vector3(0.8f, 0.5f, 0.8f);

            projectileInMotion = false;
            projectileRb.velocity = new Vector3(0, 0, 0);
            projectile.transform.position = player.transform.Find(
                "Projectile Placeholder").transform.position;
        }
    }
}
