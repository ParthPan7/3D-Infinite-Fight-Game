using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image Health_UI;
    // Start is called before the first frame update
    void Awake()
    {
        Health_UI = GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
    }

    public void DisplayHealth(float health){

        health /= 100f;
        if (health < 0f)
            health = 0f;
        Health_UI.fillAmount = health;
    }
}
