using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEnemyCtrl : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    [SerializeField]
    private bool applyKnockBack;
    [SerializeField]
    private GameObject hitParticle;
    private float currentHealth;
    [SerializeField]
    private Animator aliveAnim;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Damage(float amount)
    {
        currentHealth -= amount;
        Instantiate(hitParticle, transform.position, Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Eneemy Die");

    }
}
