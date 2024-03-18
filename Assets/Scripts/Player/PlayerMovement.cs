using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed;
    [SerializeField] Vector2 movementDirection;

    PlayerActions actions;
    PlayerData playerData;
    Rigidbody2D rb;
    PlayerAnimations playerAnimations;

    private void Awake()
    {
        actions = new PlayerActions();
        playerData = GetComponent<PlayerData>();
        rb = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ReadMovement()
    {
        movementDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        if (movementDirection == Vector2.zero)
        {
            playerAnimations.HandleMoveBoolAnimation(false);
            return;
        }

        playerAnimations.HandleMoveBoolAnimation(true);
        playerAnimations.HandleMovingAnimations(movementDirection);
    }

    void Move()
    {
        if (playerData.PlayerStats.CurrentHealth <= 0)
            return;

        rb.MovePosition(rb.position + movementDirection * (movementSpeed * Time.fixedDeltaTime));
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }
}
