using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float speed = 5;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] float shootDelay = 0.5f;

    float timeToNextShot = 0;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (CanShoot())
        {
            Shoot();
        }
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.forward + Vector3.left) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.forward + Vector3.right) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 225, 0);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.back + Vector3.left) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.back + Vector3.right) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 315, 0);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.left * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, 0, 0)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, 0, 0)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.back * bulletSpeed;

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

    public float GetSpeed()
    {
        return speed;
    }
}
