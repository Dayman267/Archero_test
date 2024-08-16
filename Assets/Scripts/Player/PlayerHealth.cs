using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    private float health;

    private Image bar;

    public static Action onDeath;

    private void Awake()
    {
        health = maxHealth;
        bar = GameObject.FindWithTag("HealthImage").GetComponent<Image>();
    }

    private void Update()
    {
        bar.fillAmount = health / maxHealth;
    }

    public void GetDamage(float damage)
    {
        if (health - damage > 0) health -= damage;
        else
        {
            health = 0;
            onDeath?.Invoke();
            Destroy(gameObject, 0.01f);
        }
    }

    public void RestoreHealth(float points)
    {
        if (health + points < maxHealth) health += points;
        else health = maxHealth;
    }
}
