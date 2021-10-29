using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionShooting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] float bulletSpeed = 20;
    [SerializeField] float shootDelay = 2;
    [SerializeField] float shootDistance = 50;

    float timeToNextShot = 0;

    List<GameObject> enemyList;

    void Start()
    {
        enemyList = FindObjectOfType<GameManager>().GetEnemies();
    }
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
        int closestEnemyIndex = 0;

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] != null)
            {
                closestEnemyIndex = i;
                break;
            }
        }

        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] != null)
            {
                if (Vector3.Distance(transform.position, enemyList[i].transform.position) < Vector3.Distance(transform.position, enemyList[closestEnemyIndex].transform.position))
                {
                    closestEnemyIndex = i;
                }
            }
        }

        if (Vector3.Distance(transform.position, enemyList[closestEnemyIndex].transform.position) <= shootDistance)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.Euler(new Vector3(0, 0, 0)));

            bullet.GetComponent<Rigidbody>().velocity = (enemyList[closestEnemyIndex].transform.position - transform.position).normalized * bulletSpeed;

            Destroy(bullet, 5);
        }
    }

    bool CanShoot()
    {
        if (FindObjectOfType<GameManager>().AllEnemiesDead())
        {
            return false;
        }
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
