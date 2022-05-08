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
    int Health = 100;
    public int playerHealth;


    private void Start()
    {
        weapon = Weapons.Fists;
        playerHealth = Health;
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

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            weapon = Weapons.Fists;
            print("Fists");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapon = Weapons.Blunt;
            print("Blunt");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapon = Weapons.Sword;
            print("Sword");
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

    public void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        if(playerHealth <= 0)
        {
            Debug.Log("Player is Dead!");
        }
    }
}
