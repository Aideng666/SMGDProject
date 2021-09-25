using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int _health = 100;
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _damage = 5;

    // Update is called once per frame
    void Update()
    {
        if (_health > _maxHealth)
        {
            _health = _maxHealth;
        }

        if (_health < 1)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public int GetDamage()
    {
        return _damage;
    }

    public int GetHealth()
    {
        return _health;
    }
}
