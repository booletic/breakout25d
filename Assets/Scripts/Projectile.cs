using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        // if projectile collides with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        // to avoid projectile from stuck bouncing horizonally
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (gameObject.transform.position.z <= 0)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward, ForceMode.Impulse);
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back, ForceMode.Impulse);
            }
        }
    }
}
