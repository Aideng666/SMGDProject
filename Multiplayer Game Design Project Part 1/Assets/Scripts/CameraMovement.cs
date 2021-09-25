using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform playerPos;
    [SerializeField] float freeCamRange = 2;
    [SerializeField] float zCamOffset = -11;



    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.x - transform.position.x > freeCamRange)
        {
            transform.position += Vector3.right * Time.deltaTime * player.GetComponent<PlayerController>().GetSpeed();
        }
        if (playerPos.position.x - transform.position.x < -freeCamRange)
        {
            transform.position += Vector3.left * Time.deltaTime * player.GetComponent<PlayerController>().GetSpeed();
        }
        if (playerPos.position.z - transform.position.z > freeCamRange - zCamOffset)
        {
            transform.position += Vector3.forward * Time.deltaTime * player.GetComponent<PlayerController>().GetSpeed();
        }
        if (playerPos.position.z - transform.position.z < -freeCamRange - zCamOffset)
        {
            transform.position += Vector3.back * Time.deltaTime * player.GetComponent<PlayerController>().GetSpeed();
        }
    }
}
