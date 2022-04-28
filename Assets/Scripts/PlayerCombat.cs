using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    public Weapons weapon;
    public int damageMultiplier;


    private void Start()
    {
        damageMultiplier = 1;
    }

    void Update()
    {
        WeaponDamage();
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(20 * damageMultiplier);
        }
        
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void WeaponDamage()
    {
        switch (weapon)
        {
            case Weapons.Fists:
                damageMultiplier = 2;
                break;
            case Weapons.Blunt:
                damageMultiplier = 3;
                break;
            case Weapons.Sword:
                damageMultiplier = 1;
                break;
            default:
                damageMultiplier = 1;
                break;
        }
    }
}
