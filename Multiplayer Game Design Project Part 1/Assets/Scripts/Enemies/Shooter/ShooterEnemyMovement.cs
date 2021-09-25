using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 6;
    [SerializeField] float viewDistance = 50;
    [SerializeField] float stopDistance = 20;

    bool withinView;
    bool tooClose;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log((FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude);
        }

        if ((FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < viewDistance)
        {
            withinView = true;
        }
        else
        {
            withinView = false;
        }

        if ((FindObjectOfType<PlayerController>().transform.position - transform.position).magnitude < stopDistance)
        {
            tooClose = true;
        }
        else
        {
            tooClose = false;
        }

        if (withinView && !tooClose)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 moveDir = (FindObjectOfType<PlayerController>().transform.position - transform.position).normalized;

        transform.position += moveDir * speed * Time.deltaTime;

        transform.LookAt(FindObjectOfType<PlayerController>().transform.position);
    }
}
