using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Image healthbar;
    float currentHealth;
    float maxHealth = 100;
    Player player;

    void Start()
    {
        healthbar = GetComponent<Image>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        currentHealth = player.GetHealth();

        healthbar.fillAmount = currentHealth / maxHealth;

        if (currentHealth > 50)
        {
            healthbar.color = Color.green;
        }
        else if (currentHealth > 25)
        {
            healthbar.color = Color.yellow;
        }
        else
        {
            healthbar.color = Color.red;
        }
    }
}
