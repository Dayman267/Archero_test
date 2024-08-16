using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float health;
    private bool isDead;

    public static Action<int> onEnemyDeath;
    [SerializeField] private int coins;

    private void Awake()
    {
        health = maxHealth;
    }

    public void GetDamage(float damage)
    {
        if(isDead) return;
        if (health - damage > 0) health -= damage;
        else
        {
            isDead = true;
            health = 0;
            onEnemyDeath?.Invoke(coins);
            Destroy(gameObject);
        }
    }
}
