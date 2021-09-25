using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 8;
    [SerializeField] float viewDistance = 50;

    // Update is called once per frame
    void Update()
    {
        if ((FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < viewDistance)
        {
            Vector3 moveDir = (FindObjectOfType<PlayerController>().transform.position - transform.position).normalized;

            transform.position += moveDir * speed * Time.deltaTime;

            transform.LookAt(FindObjectOfType<PlayerController>().transform.position);
        }
    }
}
