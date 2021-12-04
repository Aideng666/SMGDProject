using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    [SerializeField] int _health = 20;
    [SerializeField] int _damage = 20;
    

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

        FindObjectOfType<AudioManager>().Play("EnemyDamage");
    }

    void Die()
    {
        int powerupChance = Random.Range(0, 10);

        if (powerupChance == 0)
        {
            FindObjectOfType<GameManager>().SpawnPowerup(new Vector3(transform.position.x, -3, transform.position.z));
        }

        Destroy(gameObject);

        FindObjectOfType<AudioManager>().Play("EnemyDeath");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);

            TakeDamage(FindObjectOfType<Player>().GetDamage());
        }
    }

    public int GetDamage()
    {
        return _damage;
    }
}
