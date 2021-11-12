using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int health = 100;
    public int damage = 20;
    Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = health.ToString();
    }

    public void LoseHealth()
    {
        health -= damage;
        UpdateDisplay();

        if(health <= 0)
        {
            FindObjectOfType<LevelController>().HandleGameOverCondition();
        }
    }
}
