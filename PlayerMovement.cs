using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Rigidbody2D player;
    float horizantalMove = 0f;
    bool oneJump = false;
    bool Crouched = false;
    public float Runspeed = 100f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public Transform attackPos;
    public LayerMask whatisenemy;
    public float attackRange;
    public int damage;
    void Update()
    {
        
        horizantalMove = Input.GetAxisRaw("Horizontal") * Runspeed;
        animator.SetFloat("Speed", Mathf.Abs(horizantalMove));
        if( Input.GetButtonDown("Jump"))
        {
            oneJump = true;
            animator.SetBool("IsJumping", oneJump);
        }
        if( Input.GetButtonDown("Crouch"))
        {
            
            Crouched = true;
            animator.SetBool("IsCrouching", Crouched);
            Debug.Log(Crouched);
        }
        if (Input.GetButtonUp("Crouch"))
        {
            Crouched = false;
            animator.SetBool("IsCrouching", Crouched);
            
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("IsAttacking", true);
            Collider2D[] enemiesTodamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange,whatisenemy);
            for (int i = 0; i <enemiesTodamage.Length;i++)
            {
                enemiesTodamage[i].GetComponent<enemyHP>().TakeDamage(damage);
            }
            
        }
    }
    public void OnLanding()
    {
        animator.SetBool("IsJumping",false);
        oneJump = false;
    }
    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching); 
    }
    void FixedUpdate()
    {
        //player.velocity = new Vector2(horizantalMove,0);
        controller.Move(horizantalMove * Time.fixedDeltaTime, Crouched, oneJump);
        animator.SetBool("IsAttacking", false);


        
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
}
