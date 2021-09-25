using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] float shootDelay = 2f;
    [SerializeField] float shootDistance = 30;

    float timeToNextShot = 0;

    // Update is called once per frame
    void Update()
    {
        if (CanShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if ((FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < shootDistance)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

            bullet.GetComponent<Rigidbody>().velocity = (FindObjectOfType<PlayerController>().transform.position - transform.position).normalized * bulletSpeed;

            Destroy(bullet, 5);
        }
    }
    bool CanShoot()
    {
        if (timeToNextShot < Time.realtimeSinceStartup)
        {
            timeToNextShot = Time.realtimeSinceStartup + shootDelay;
            return true;
        }
        else
        {
            return false;
        }
    }
}
