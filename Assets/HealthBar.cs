using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider healthBar;
	
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.value = 1.0f;
    }
    
    public void SetHealth(float health) 
    {
		healthBar.value = health;
	}

}
