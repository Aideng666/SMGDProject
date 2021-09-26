using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float followRange = 5;

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - transform.position).magnitude > followRange)
        {
            transform.position += new Vector3(player.transform.position.x - transform.position.x,
                                              0, player.transform.position.z - transform.position.z)
                                              * Time.deltaTime * player.GetComponent<PlayerController>().GetSpeed();
        }
    }
}
