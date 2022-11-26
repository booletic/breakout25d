using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCrazy : Projectile
{
    public override void OnCollisionEnter(Collision collision)
    {
        // if projectile collide with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            AudioSource.PlayOneShot(blipAC);
        }
        // if projectile collide with player right-side
        if (collision.gameObject.CompareTag("Right"))
        {

            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.left, ForceMode.Impulse);
        }

        // if projectile collide with player left-side
        if (collision.gameObject.CompareTag("Left"))
        {
            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.right, ForceMode.Impulse);
        }

        // if projectile collide with player mid-side
        if (collision.gameObject.CompareTag("Middle"))
        {
            AudioSource.PlayOneShot(blipAC);
            ProjectileRb.AddForce(speed * Vector3.up, ForceMode.Impulse);
        }
    }
}
