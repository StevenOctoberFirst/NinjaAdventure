using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    Animator anim;

    readonly int moveX = Animator.StringToHash("MoveX");
    readonly int moveY = Animator.StringToHash("MoveY");
    readonly int isMoving = Animator.StringToHash("isMoving");
    readonly int gotKilled = Animator.StringToHash("gotKilled");
    readonly int revived = Animator.StringToHash("revived");
    readonly int isAttacking = Animator.StringToHash("isAttacking");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void HandleDeadAnimation()
    {
        anim.SetTrigger(gotKilled);
    }

    public void HandleMoveBoolAnimation(bool value)
    {
        anim.SetBool(isMoving, value);
    }

    public void HandleMovingAnimations(Vector2 value)
    {
        anim.SetFloat(moveX, value.x);
        anim.SetFloat(moveY, value.y);
    }

    public void HandleReviveAnimation()
    {
        anim.SetTrigger(revived);
        HandleMovingAnimations(Vector2.down);
    }

    public void SetAttackingAnimation(bool value)
    {
        anim.SetBool(isAttacking, value);
    }
}
