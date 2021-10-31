using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] int _health = 20;

    // Update is called once per frame
    void Update()
    {
        if (_health < 1)
        {
            Die();
        }
    }

    void TakeDamage(int damage)
    {
        _health -= damage;
    }

    void Die()
    {
        int powerupChance = Random.Range(0, 10);

        if (powerupChance == 0)
        {
            FindObjectOfType<GameManager>().SpawnPowerup(new Vector3(transform.position.x, -3, transform.position.z));
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            TakeDamage(FindObjectOfType<Player>().GetDamage());
        }
    }
}
