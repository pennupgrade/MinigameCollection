using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    // Declare and initialize a new List of GameObjects called currentCollisions.
    private List<GameObject> currentCollisions;
    public GameObject explosionAnimation;
    
    void OnTriggerEnter(Collider col)
    {
        // Add the GameObject collided with to the list.
        currentCollisions.Add (col.gameObject);
    }

    void OnTriggerExit(Collider col)
    {
        // Remove the GameObject collided with from the list.
        currentCollisions.Remove (col.gameObject);
    }

    public void Damage(int damage)
    {
        GameManager.Instance.ShakeCamera();
        Instantiate(
            explosionAnimation,
            new Vector3(transform.position.x, 3, transform.position.z),
            Quaternion.identity
        ); 
        for (int i = 0; i < currentCollisions.Count; i++)
        {
            if (currentCollisions[i] == null)
            {
                currentCollisions.Remove(currentCollisions[i]);
                i --;
            }
            else
            {
                Enemy e = currentCollisions[i].GetComponent<Enemy>();
                if (e != null) {
                    e.Damage(damage);
                    
                    
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCollisions = new List <GameObject> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
