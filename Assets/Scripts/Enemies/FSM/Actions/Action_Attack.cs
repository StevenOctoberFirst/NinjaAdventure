using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Attack : FSM_Action
{
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] float damage;

    EnemyBrain brain;
    float attackTimer;

    private void Awake()
    {
        brain = GetComponent<EnemyBrain>();
    }

    private void Start()
    {
        attackTimer = timeBetweenAttacks;
    }

    public override void Act()
    {
        AttackPlayer();
    }
    
    private void AttackPlayer()
    {
        if (brain.Player == null)
            return;

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0)
        {
            //Attack
            IDamagable player = brain.Player.GetComponent<IDamagable>();
            player.TakeDamage(damage);
            attackTimer = timeBetweenAttacks;
        }
    }
}
