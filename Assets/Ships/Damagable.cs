using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public int health;

    private Color originalColour;
    private bool colourSet;

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(this.gameObject);
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        StartCoroutine(HitRoutine());
    }    

    IEnumerator HitRoutine()
    {
        if(!colourSet)
        {
            originalColour = GetComponent<SpriteRenderer>().color;
            colourSet = true;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = originalColour;
    }
}
