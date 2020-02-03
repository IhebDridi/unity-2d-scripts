using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnooper : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
            RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
            if (hitInfo)
            {
                if (hitInfo.transform.name == "hero")
                {
                    
                    animator.SetTrigger("IsAttacking");

                }
            }
        

    }
    
}
