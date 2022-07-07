using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalInput;
    public float boundry;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // user-input to move pedal sideways
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

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
            if (!gameManager.projectileInMotion)
            {
                GameObject projectile = GameObject.FindGameObjectWithTag("Projectile");
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                Projectile projectileScript = projectile.GetComponent<Projectile>();

                float projectileSpeed = projectileScript.speed;

                projectileRb.AddForce(
                    new Vector3(
                        Random.Range(-1.0f, 1.01f), 0, 1) * projectileSpeed,
                    ForceMode.Impulse);

                gameManager.projectileInMotion = true;
            }
        }
    }
}
