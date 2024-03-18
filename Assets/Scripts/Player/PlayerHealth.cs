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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerStats.CurrentHealth > 0)
        {
            TakeDamage(1f);
        }
    }

    public void TakeDamage(float damage)
    {
        playerStats.CurrentHealth -= damage;
        
        if(playerStats.CurrentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerAnimations.HandleDeadAnimation();
        print("Ur dead bro... kinda cringe");
    }
}
