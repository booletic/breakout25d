using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public AudioClip blipAC;
    public AudioClip hitAC;
    public bool hasPowerup;

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
        if (hasPowerup)
        {
            StartCoroutine(ScalePowerupRoutine());
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

            if (gameObject.transform.position.z <= 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back, ForceMode.Impulse);
            }
        }

        // if projectile collide with player right-side
        if (collision.gameObject.CompareTag("Right"))
        {
            audioSource.PlayOneShot(blipAC);
            GetComponent<Rigidbody>().AddForce(0.5f * speed * Vector3.right, ForceMode.Impulse);
        }

        // if projectile collide with player left-side
        if (collision.gameObject.CompareTag("Left"))
        {
            audioSource.PlayOneShot(blipAC);
            GetComponent<Rigidbody>().AddForce(0.5f * speed * Vector3.left, ForceMode.Impulse);
        }
    }

    IEnumerator ScalePowerupRoutine()
    {
        // grow projectile temprorary
        hasPowerup = false;
        transform.localScale = new Vector3(1.6f, 0.5f, 1.6f);
        yield return new WaitForSeconds(5);
        transform.localScale = new Vector3(0.8f, 0.5f, 0.8f);
    }
}
