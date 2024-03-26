using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamagable
{
    [SerializeField] PlayerStats playerStats;

    PlayerAnimations playerAnimations;

    private void Awake()
    {
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void TakeDamage(float damage)
    {
        if (playerStats.CurrentHealth <= 0)
            return;

        playerStats.CurrentHealth -= damage;
        DamageManager.i.showDamageText(this.transform, damage);
        
        if(playerStats.CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerAnimations.HandleDeadAnimation();
    }
}
