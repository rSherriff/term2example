using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThreeFanWeapon", menuName = "ScriptableObjects/Weapons/ThreeFan", order = 1)]
public class ThreeFanWeapon : Weapon
{
    public float speed;
    public int damage;
    public float angle;
    public float spread;

    public override IEnumerator Shoot(Transform transform)
    {
        currentCooldown = 0;
        while (true)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = cooldown;

                Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                Bullet bullet = BulletManager.Instance.GetBullet(bulletType);
                bullet.Setup(transform.position, direction, speed, 2, damage);

                direction = new Vector2(Mathf.Cos((angle + spread) * Mathf.Deg2Rad), Mathf.Sin((angle + spread) * Mathf.Deg2Rad));
                bullet = BulletManager.Instance.GetBullet(bulletType);
                bullet.Setup(transform.position, direction, speed, 2, damage);

                direction = new Vector2(Mathf.Cos((angle - spread) * Mathf.Deg2Rad), Mathf.Sin((angle - spread) * Mathf.Deg2Rad));
                bullet = BulletManager.Instance.GetBullet(bulletType);
                bullet.Setup(transform.position, direction, speed, 2, damage);
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }
            yield return null;
        }
    }
}
