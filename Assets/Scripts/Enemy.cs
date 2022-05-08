using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyMovement { patrol, chase}

public class Enemy : MonoBehaviour
{
    public int enemyHealth = 100;
    int currentHealth;
    public Transform moveToPos;
    public Transform[] wayPoints;
    public float mySpeed = 1;
    public EnemyMovement enemyMovement;
    public int currentWaypoint = 0;
    public Transform playerLocation;
    public Transform attackPoint;
    public Transform playerBack;
    public float attackRange = 0.5f;
    float detectionTime;
    public PlayerMovement playerMovement;
    
    void Start()
    {
        currentHealth = enemyHealth;
        MovementTypes();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    IEnumerator Move()
    {
        
        moveToPos = wayPoints[currentWaypoint];
        while (Vector2.Distance(transform.position, moveToPos.position) > 0.1f)
        {

            transform.position = Vector2.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            yield return null;
        }
        if(currentWaypoint == wayPoints.Length - 1)
        {
            currentWaypoint = 0;
        }
        else
        {
            currentWaypoint++;
        }
        
        transform.Rotate(Vector2.up * 180);
        yield return new WaitForSeconds(3);
        StartCoroutine(Move());
    }

    IEnumerator Chase()
    {
        Debug.Log("Player is seen");
        if(playerMovement.FacingRight())
        {
            moveToPos = playerLocation;
        }
        else
        {
            moveToPos = playerBack;
        }
        while (Vector2.Distance(transform.position, moveToPos.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToPos.position, Time.deltaTime * mySpeed);
            yield return null;
        }
        //EnemyAttack();
        Debug.Log("Player is being chased!");
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            enemyMovement = EnemyMovement.chase;
            MovementTypes();

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        enemyMovement = EnemyMovement.patrol;
        MovementTypes();
    }

    void EnemyAttack()
    {

        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerCombat>().PlayerDamage(20);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void MovementTypes()
    {
        StopAllCoroutines();
        switch(enemyMovement)
        {
            case EnemyMovement.patrol:
                StartCoroutine(Move());
                break;
            case EnemyMovement.chase:
                
                StartCoroutine(Chase());
                
                break;
            default:
                StartCoroutine(Move());
                break;
        }
    }
    
}
