﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.GetComponent<PlayerMovementV2>() !=null)
        {
            collision.GetComponent<PlayerMovementV2>().TakeDamage(20);
            Destroy(gameObject);
        }
        
    }
}
