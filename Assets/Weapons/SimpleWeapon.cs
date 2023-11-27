using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleWeapon", menuName = "ScriptableObjects/Weapons/Simple", order = 1)]
public class SimpleWeapon : Weapon
{
    public float speed;
    public int damage;

    public override IEnumerator Shoot(Transform transform)
    {
        currentCooldown = 0;
        while (true)
        {
            if (currentCooldown <= 0)
            {
                currentCooldown = cooldown;
                Bullet bullet = BulletManager.Instance.GetBullet(bulletType);
                bullet.Setup(transform.position, Vector2.up, speed, 2, damage);
            }
            else
            {
                currentCooldown -= Time.deltaTime;
            }
            yield return null;
        }
    }
}
