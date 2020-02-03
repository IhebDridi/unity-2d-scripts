using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject child;
    private Transform tr;
    private float Hp;
    private float DamageTimer;
    void Start()
    {
        tr = transform.GetChild(0);
        Hp=tr.GetComponent<enemyHP>().health;
        
    }

    // Update is called once per frame
    void Update()
    {
        Hp = tr.GetComponent<enemyHP>().health;
        
        Debug.Log("Parent Health"+Hp);
        //DamageTimer = Time.realtimeSinceStartup + 2;
        if (Hp <= 0)
        {
            if (Time.realtimeSinceStartup.CompareTo(DamageTimer) == 1)
            {
                Destroy(gameObject,1f);
            }
        }
    }
}
