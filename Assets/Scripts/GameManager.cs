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
        if (!projectileInMotion)
        {
            projectile.transform.position = player.transform.position + new Vector3(0, 0, 1);
        }
        
    }
}
