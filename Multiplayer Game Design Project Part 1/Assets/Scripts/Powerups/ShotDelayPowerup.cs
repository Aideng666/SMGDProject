using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotDelayPowerup : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), 0.2f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<ApplyShotDelayPowerup>().ActivatePowerup();
            Destroy(gameObject);
        }
    }
}
