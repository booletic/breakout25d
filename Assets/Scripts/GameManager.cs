using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject projectilePrefab;
    public bool projectileInMotion;

    private GameObject projectile;
    private Rigidbody projectileRb;
    private Projectile projectileScript;


    void Start()
    {
        projectileInMotion = false;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn a new projectile after destroy
        if (projectile == null)
        {
            Instantiate(projectilePrefab);
            projectile = GameObject.FindWithTag("Projectile");
            projectileRb = projectile.GetComponent<Rigidbody>();
            projectileScript = projectile.GetComponent<Projectile>();
        }

        // projectile tracks player
        if (!projectileInMotion)
        {
            projectile.transform.position = new Vector3(
                player.transform.position.x, 
                projectile.transform.position.y,
                projectile.transform.position.z);
        }
        
        // destroy projectile if out of boundy
        if (projectile.transform.position.z < -20)
        {
            projectileInMotion = false;
            Destroy(obj: projectile);
            projectile = null;
        }
    }
}
