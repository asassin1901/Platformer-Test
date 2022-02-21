using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int maxHealth = 80;
    private int currentHealth;

    Animator enemAnimator = null;

    private void Awake()
    {
        enemAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        Debug.Log("Hit");

        enemAnimator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            enemAnimator.SetBool("isDead", true);
            Invoke("Die", 0.5f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
