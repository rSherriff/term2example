using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : ScriptableObject
{
    public float cooldown;
    protected float currentCooldown;
    public BulletManager.bulletType bulletType;
    abstract public IEnumerator Shoot(Transform transform);
}
