using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public float Timer1=5;
    public float Timer2 = 10;
    public float Timer3 = 10;
    public float Rest1;
    public float Rest2;
    public float Rest3;
    public Image Skill1On;
    public Image Skill2On;
    public Image Skill3On;
    public Text Skill1;
    public Text Skill2;
    public Text Skill3;
    private GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        //Skill1On = transform.Find("Skill1On").GetComponent<Image>();
    }
    void Start()
    {
        
        Skill1.text = Timer1.ToString()+"s";
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Timer1 -= player.GetComponent<PlayerMovementV2>().Skill1();
        //Timer2 -= player.GetComponent<PlayerMovementV2>().Skill2();
        //Timer3 -= player.GetComponent<PlayerMovementV2>().Skill3();

        Skill1.text = Mathf.Round(Timer1).ToString()+"s";
        //Skill2.text = Mathf.Round(Timer2).ToString() + "s";
        //Skill3.text = Mathf.Round(Timer3).ToString() + "s";

        if (Timer1 <= 0)
        {
            Skill1.text = "";

            Rest1 = 1;
        }
        else
        {
            Rest1 = (1/ Timer1) / 5.0f;
        }
        setFiller1(Rest1);
       /* if (Timer2 <= 0)
        {
            Skill2.text = "";

            Rest2 = 1;
        }
        else
        {
            Rest2 = (1 / Timer1) / 10.0f;
        }
        setFiller2(Rest2);
        if (Timer2 <= 0)
        {
            Skill2.text = "";

            Rest3 = 1;
        }
        else
        {
            Rest3 = (1 / Timer1) / 10.0f;
        }
        setFiller3(Rest3);*/

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Timer1 -= player.GetComponent<PlayerMovementV2>().Skill1();
        }

    }
    private void setFiller1(float Filling)
    {
        Skill1On.fillAmount = Filling;
    }
    private void setFiller2(float Filling)
    {
        Skill2On.fillAmount = Filling;
    }
    private void setFiller3(float Filling)
    {
        Skill2On.fillAmount = Filling;
    }

}
