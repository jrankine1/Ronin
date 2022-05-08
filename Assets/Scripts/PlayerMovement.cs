using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Video Tutorial: https://www.youtube.com/watch?v=9HAZQROH2gM

    public float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = true;
    private float moveDirection;
    public float jumpForce;
    private bool isjumping = false;
    public Transform groundCheck;
    public LayerMask groundObjects;
    private bool isGrounded;
    public float checkRadius;
    public int playerHealth = 100;
    
    public PlayerCombat playerCombat;
    Animator anim;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");


        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

        

        if(moveDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if(moveDirection < 0 && facingRight)
        {
            FlipCharacter();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            Attack();

        }

        
    }

    private void FixedUpdate()
    {
        Jump();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObjects);
    }

    private void FlipCharacter()
    {
        if(CompareTag("Player"))
        {
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);
        }
        

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isjumping = true;
        }


        if (isjumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
        }
        isjumping = false;
    }

    void Attack()
    {
        //Debug.Log(weaponManager.weapon);
        switch(playerCombat.weapon)
        {
            case Weapons.Fists:
                anim.SetTrigger("Attack 1");
                break;
            case Weapons.Blunt:
                anim.SetTrigger("Attack 2");
                break;
            case Weapons.Sword:
                anim.SetTrigger("Attack 3");
                break;
        }
        
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
    }

    public bool FacingRight()
    {
        return facingRight;
    }
}
