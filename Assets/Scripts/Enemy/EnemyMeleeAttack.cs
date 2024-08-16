using System;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField] private float secBetweenAttack = 0.5f;
    [SerializeField] private float meleeDamage = 15f;
    private bool canAttack;
    private float secLeft;
    private void FixedUpdate()
    {
        if (secLeft <= 0)
        {
            canAttack = true;
        }
        else secLeft -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if(!collider.gameObject.CompareTag("Player")) return;
        if (canAttack)
        {
            collider.GetComponent<PlayerHealth>().GetDamage(meleeDamage);
            canAttack = false;
            secLeft = secBetweenAttack;
        }
    }
}
