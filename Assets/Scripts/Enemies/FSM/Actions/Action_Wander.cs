using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Action_Wander : FSM_Action
{

    [SerializeField] float moveSpeed;
    [SerializeField] float wanderTime;
    [SerializeField] Vector2 moveRange;

    float moveTimer;
    Vector3 moveDestination;

    private void Start()
    {
        GetNewDestination();
    }

    public override void Act()
    {
        moveTimer -= Time.deltaTime;

        var moveDirection = (moveDestination - transform.position).normalized;
        var movement = moveDestination * (moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveDestination) >= .5f)
        {
            transform.Translate(movement);
        }

        if (moveTimer <= 0)
        {
            GetNewDestination();
            moveTimer = wanderTime;
        }
    }

    void GetNewDestination()
    {
        var randomX = Random.Range(-moveDestination.x, moveDestination.x);
        var randomY = Random.Range(-moveDestination.y, moveDestination.y);

        moveDestination = transform.position = new Vector3(randomX, randomY);
    }

    private void OnDrawGizmosSelected()
    {
        if (moveRange != Vector2.zero)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(transform.position, moveRange * 2f);
            Gizmos.DrawLine(transform.position, moveDestination);
        }
    }
}
