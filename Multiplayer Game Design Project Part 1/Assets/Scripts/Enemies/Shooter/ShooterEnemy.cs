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
    }

    void Die()
    {
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

    public int GetDamage()
    {
        return _damage;
    }
}
