using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image barImage;
    private GameObject player;
    private float NormalisedHp;
    private void Awake()
    {
        barImage = transform.Find("filled hp bar").GetComponent<Image>();
        
    }
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void Update()
    {
        NormalisedHp = player.GetComponent<PlayerMovementV2>().GetHealthNormalized();
        setHealth(NormalisedHp);
    }
    // Start is called before the first frame update
    private void setHealth(float healthNormalised)
    {
        barImage.fillAmount = healthNormalised;
    }
}
