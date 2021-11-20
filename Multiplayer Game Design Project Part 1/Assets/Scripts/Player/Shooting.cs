using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] float shootDelay = 0.5f;
    float timeToNextShot = 0;

    public void ShootButtonUp()
    {
        if (CanShoot())
        {
            playerPrefab.transform.rotation = Quaternion.Euler(0, 180, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, -90, 0)));
            bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;
            Destroy(bullet, 5);
        } 
    }
    
    public void ShootButtonDown()
    {
        if (CanShoot())
        {
            playerPrefab.transform.rotation = Quaternion.Euler(0, 0, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, 90, 0)));
            bullet.GetComponent<Rigidbody>().velocity = Vector3.back * bulletSpeed;
            Destroy(bullet, 5);
        } 
    }
    
    public void ShootButtonLeft()
    {
        if (CanShoot())
        {
            playerPrefab.transform.rotation = Quaternion.Euler(0, 90, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 180, 0)));
            bullet.GetComponent<Rigidbody>().velocity = Vector3.left * bulletSpeed;
            Destroy(bullet, 5);
        }
    }
    
    public void ShootButtonRight()
    {
        if (CanShoot())
        {
            playerPrefab.transform.rotation = Quaternion.Euler(0, 270, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            bullet.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;
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