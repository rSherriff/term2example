using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Bullet
{
    override public void Setup(Vector3 position, Vector2 direction, float speed, float lifespan, int damage = 1)
    {
        base.Setup(position, direction * -1, speed, lifespan, damage);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<Player>().Damage(damage);
            this.gameObject.SetActive(false);
        }
    }
}
