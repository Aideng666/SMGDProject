using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] float speed = 5;
    [SerializeField] float shootDelay = 0.5f;
    [SerializeField] float knockbackPower = 25;
    [SerializeField] int contactDamageRecieved = 10;

    float timeToNextShot = 0;

    bool isShooting = false;

    Rigidbody body;

    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();

        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.forward + Vector3.left) * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.forward + Vector3.right) * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 225, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            transform.position += (Vector3.back + Vector3.left) * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.back + Vector3.right) * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 315, 0);
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (!isShooting)
            {
                transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.RightArrow) && CanShoot())
        {
            isShooting = true;

            transform.rotation = Quaternion.Euler(0, 270, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.right * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && CanShoot())
        {
            isShooting = true;

            transform.rotation = Quaternion.Euler(0, 90, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 90)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.left * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && CanShoot())
        {
            isShooting = true;

            transform.rotation = Quaternion.Euler(0, 180, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, 0, 0)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.forward * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && CanShoot())
        {
            isShooting = true;

            transform.rotation = Quaternion.Euler(0, 0, 0);

            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(90, 0, 0)));

            bullet.GetComponent<Rigidbody>().velocity = Vector3.back * bulletSpeed;

            Destroy(bullet, 5);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            isShooting = true;
        }
        else
        {
            isShooting = false;
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

    void ApplyKnockback(Vector3 direction)
    {
        body.AddForce(direction * knockbackPower, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            ApplyKnockback((transform.position - collision.transform.position).normalized);

            FindObjectOfType<Player>().TakeDamage(contactDamageRecieved);
        }

        if (collision.gameObject.tag == "Enemy Bullet")
        {
            ApplyKnockback((transform.position - collision.transform.position).normalized);

            FindObjectOfType<Player>().TakeDamage(FindObjectOfType<ShooterEnemy>().GetDamage());
        }

        if (collision.gameObject.tag == "Platform")
        {
            if (FindObjectOfType<GameManager>().AllEnemiesDead())
            {
                SceneManager.LoadScene("Level Complete");
            }
        }
    }

    public float GetSpeed()
    {
        return speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public float GetShotDelay()
    {
        return shootDelay;
    }

    public void SetShotDelay(float delay)
    {
        shootDelay = delay;
    }
}
