using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    private string enemies;
    public Text Counter;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
        Debug.Log("there are this many enemies in the game"+enemies);


        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = (GameObject.FindGameObjectsWithTag("Enemy").Length / 2 ).ToString();

        Counter.text = "there are this many enemies in the game" + enemies;
    }
}
