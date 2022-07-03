using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float boundry;

    private GameObject projectile;
    private Rigidbody projectileRb;
    private Projectile projectileScript;

    // Start is called before the first frame update
    void Start()
    {
        projectile = GameObject.Find("Projectile");
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileScript = projectile.GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        // user-input to move pedal sideways
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.down);

        // limit pedal right movement
        if (transform.position.x > boundry)
        {
            transform.position = new Vector3(boundry, transform.position.y, transform.position.z);
        }

        // limit pedal left movement
        if (transform.position.x < -boundry)
        {
            transform.position = new Vector3(-boundry, transform.position.y, transform.position.z);
        }

        // launch projectile on user-input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (projectileRb.velocity.magnitude == 0)
            {
                float projectileSpeed = projectileScript.speed;
                projectileRb.AddForce(Vector3.forward * projectileSpeed, ForceMode.Impulse);
            }
        }
    }
}
