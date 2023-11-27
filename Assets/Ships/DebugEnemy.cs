using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEnemy : MonoBehaviour
{

    int health = 10;
    int damage = 3;

    void Hit() 
    { 
        health -= damage;
        Debug.Log("Enemy Hit!");
    }

    void Die() 
    { 
        Debug.Log("Player is dead!");
        Destroy(this.gameObject);
    }

    void Update() 
    {
        if (health == 0) 
        { 
            Die(); 
        } 
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Bullet"))
        {
            Hit();

        }
    }
}
