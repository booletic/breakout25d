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
        Instantiate(projectilePrefab);
        projectile = GameObject.FindWithTag("Projectile");
        projectileRb = projectile.GetComponent<Rigidbody>();
        projectileScript = projectile.GetComponent<Projectile>();
    }

    // Update is called once per frame
    void Update()
    {
        // projectile tracks player
        if (!projectileInMotion)
        {
            projectile.transform.position = new Vector3(
                player.transform.position.x, 
                projectile.transform.position.y,
                projectile.transform.position.z);
        }
        
        // reset projectile if out of boundy
        if (projectile.transform.position.z < -20)
        {
            projectileInMotion = false;
            projectileRb.velocity = new Vector3(0, 0, 0);
            projectile.transform.position = new Vector3(
                player.transform.position.x, 0.5f, -10.75f);
        }
    }
}
