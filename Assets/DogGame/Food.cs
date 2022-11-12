using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    
    private void Update() {
        
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        Destroy(this.gameObject);
	}

}