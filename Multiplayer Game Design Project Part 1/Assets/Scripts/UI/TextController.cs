using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    [SerializeField] Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: " + FindObjectOfType<Player>().GetHealth();
    }
}
