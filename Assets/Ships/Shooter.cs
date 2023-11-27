using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Damagable
{
    public Weapon weapon;
    public Transform weaponOrigin;

    public void ShootDown()
    {
        StartCoroutine(weapon.Shoot(weaponOrigin));
    }

    public void ShootUp()
    {
        StopAllCoroutines();
    }

    public void SwapWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;
    }
}
