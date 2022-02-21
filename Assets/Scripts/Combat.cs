using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    Animator myAnimator = null;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    public int damage = 40;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }

    void Attack()
    {
        myAnimator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemies>().TakeDamage(damage);
            if(enemy.transform.position.x > transform.position.x)
            {
                enemy.attachedRigidbody.AddForce(new Vector2(2f, 2f), ForceMode2D.Impulse);
            }
            else
            {
                enemy.attachedRigidbody.AddForce(new Vector2(-2f, 2f), ForceMode2D.Impulse);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
