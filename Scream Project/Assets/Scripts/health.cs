using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public int health_amount;
    public int max_health;
    public int min_health;

    public void changeHealth(int health_change_amount)
    {
        health_amount = Mathf.Clamp((health_amount + health_change_amount), min_health, max_health);
        
        if(health_amount == min_health)
        {
            Debug.Log("print dead");
        }
        Debug.Log(health_amount);
    }
}
