using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    private Rigidbody projectileRb;
    public bool projectileInMotion;

    void Start()
    {
        projectileInMotion = false;
        projectileRb = projectile.GetComponent<Rigidbody>();
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
        
    }
}
