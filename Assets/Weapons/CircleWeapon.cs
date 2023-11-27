using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleWeapon", menuName = "ScriptableObjects/Weapons/Circle", order = 1)]
public class CircleWeapon : Weapon
{
    public float speed;
    public int damage;
    public int numBullets;

    public override IEnumerator Shoot(Transform transform)
    {
        currentCooldown = 0;
        while (true)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = cooldown;

                float angle = 0;
                float angleStep = 360 / numBullets;

                for (int i = 0; i < numBullets; i++)
                {
                    Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                    Bullet bullet = BulletManager.Instance.GetBullet(bulletType);
                    bullet.Setup(transform.position, direction, speed, 2, damage);

                    angle += angleStep;
                }
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }
            yield return null;
        }
    }
}
