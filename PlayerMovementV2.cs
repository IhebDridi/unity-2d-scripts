using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerMovementV2 : MonoBehaviour
{
    //Movement
    public float speed;
    public float jumpForce;
    private float moveInput;
    private Transform tr;


    private bool facingRight=true;
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundChecker;
    public float checkRadius;
    public LayerMask whatisGround;
    private int ExtraJumps;
    public int extraJumpVal;
    public Animator animator;
    //Damage
    public Transform attackPos;
    public LayerMask whatisenemy;
    public float attackRange;
    public int damage;
    public int attackSpeed;
    private float nextAttackTime;
    //health
    private bool IsDead = true;
    private int HealthAmount;
    private int HealthMax = 100;
    private float DeathTime;
    public GameObject tomb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        ExtraJumps = extraJumpVal;
        //tr = GetComponent<Transform>();
        HealthAmount = HealthMax;
        tr = GetComponent<Transform>();


    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundChecker.position,checkRadius,whatisGround);
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if(facingRight== false && moveInput > 0 )
        {
            flip();
        }else if (facingRight == true && moveInput < 0)
        {
            flip();
        }
    }
    private void Update()
    {

        //jump
        if(isGrounded)
        {
            ExtraJumps = extraJumpVal;
            animator.SetBool("IsJumping", false);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && ExtraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
            ExtraJumps--;
        }else if (Input.GetKeyDown(KeyCode.UpArrow) && ExtraJumps == 0 && isGrounded ==true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
        }

        //attack
        if (Input.GetKeyDown(KeyCode.K))
        {
            if(Time.time >= nextAttackTime)
            {
                animator.SetTrigger("isAttacking");
                Collider2D[] enemiesTodamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatisenemy);
            for (int i = 0; i < enemiesTodamage.Length; i++)
            {
                enemiesTodamage[i].GetComponent<enemyHP>().TakeDamage(damage);
            }
                nextAttackTime = Time.time + 1 / attackSpeed;
            }
        }
        if (HealthAmount <= 0)
        {
            
            animator.SetBool("IsDead",true);
            Debug.Log("test"+Time.realtimeSinceStartup.CompareTo(DeathTime));
            if (Time.realtimeSinceStartup.CompareTo(DeathTime) == 1)
            {
                Destroy(gameObject);
                Instantiate(tomb, transform.localPosition,Quaternion.identity);
            }

        }

        
    }
    void flip()
    {
        facingRight = !facingRight;
        //Vector3 transformOld= transform.localPosition;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        //transform.localPosition = transformOld;
        
    }
    public float GetHealthNormalized()
    {
        return (float)HealthAmount / HealthMax;
    }
    public void damaged(int amount)
    {
        HealthAmount -= amount;
        
        if(OnDamaged !=null ) OnDamaged(this,EventArgs.Empty);
        
    }
    public void healed(int amount)
    {
        HealthAmount += amount;
        if (HealthAmount > HealthMax)
        {
            HealthAmount = HealthMax;
        }
        
    }
    public GameObject damageCount;
    public void TakeDamage(int damage)
    {
        DeathTime = Time.realtimeSinceStartup + 0.3f;
        rb.velocity -= new Vector2(2f,2f);
        HealthAmount -= damage;
        Debug.Log(HealthAmount);
    }
    public float Cooldown =5;
    public float Skill1()
    {
        
        
        if (Cooldown > 0)
        {
            
            Cooldown -= Time.deltaTime;
                speed *= 2;
            
        }
        
        if (Cooldown <= 0)
        {
            Cooldown = 0;
            speed /= 2;
            return Cooldown;
        }
        return Cooldown;
    }
    public float Skill2()
    {
        Cooldown = 5;
        Cooldown -= Time.deltaTime;
        if(Cooldown >0)
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                attackRange *= 2;
            }
        }
        
        else if(Cooldown <=0)
        {
            attackRange /= 2;
            return Cooldown;
        }
        return Cooldown;
    }
    public float Skill3()
    {
        Cooldown = 5;
        Cooldown -= Time.deltaTime;
        if (Cooldown > 0)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                healed(50);
            }
        }
        
        return Cooldown;
    }
}
