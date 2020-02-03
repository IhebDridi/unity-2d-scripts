using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{

    public int health = 100;
    public Animator animator;
    float timer = 0;
    float DamageTimer = 0;
    public GameObject damageCount;
    private GameObject Enemy;
    private Transform tr;
    private GameObject player;
    public int MonsterDamage = 10;
    private float startDazeTime;
    public float DazeTime;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponentInParent<Rigidbody2D>();
        SpriteRenderer sp = GetComponent<SpriteRenderer>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Debug.Log(sp.sprite.name);
    }

    // Update is called once per frame
    void Update()
    {

        
        if (health <=0)
        {
            animator.SetBool("IsDead", true);
            /*if(Time.realtimeSinceStartup.CompareTo(timer) == 1)
            {
                
                
                
            }*/
        }
        /*if(DazeTime <=0)
        {
            rb.velocity =new Vector2(0f,rb.velocity.y);
        }*/
        
    }
    
    public void TakeDamage(int damage)
    {
        DazeTime = startDazeTime;
        GameObject damaged = Instantiate(damageCount, tr.position,tr.rotation);
        damaged.GetComponent<TextMesh>().text = damage.ToString();
        DamageTimer = Time.realtimeSinceStartup + 2;
        /*if (Time.realtimeSinceStartup.CompareTo(DamageTimer) == 1)
        {
            Destroy(damaged);
        }*/
        
        
        timer = Time.realtimeSinceStartup + 1;
        health -= damage;
        Debug.Log(health);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            player.GetComponent<PlayerMovementV2>().TakeDamage(MonsterDamage);

        }
        Debug.Log("collision");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerMovementV2>().TakeDamage(MonsterDamage);

        }
        Debug.Log("collision");
    }
}
