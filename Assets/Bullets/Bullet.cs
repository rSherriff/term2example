using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected Vector2 direction;
    [SerializeField] protected float speed;
    [SerializeField] protected int damage;
    [SerializeField] protected float lifespan;

    virtual public void Setup(Vector3 position, Vector2 direction, float speed, float lifespan, int damage = 1)
    {
        transform.position= position;
        this.direction = direction;
        this.speed = speed;
        this.damage = damage;
        this.lifespan = lifespan;

        StartCoroutine(LifeSpan());
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(lifespan);
        this.gameObject.SetActive(false);   
    }
    
}
