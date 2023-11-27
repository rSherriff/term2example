using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponPowerup", menuName = "ScriptableObjects/PowerUps/Weapon", order = 1)]
public class WeaponPowerup : PowerUp
{
    public Weapon weapon;

    override public void Apply(GameObject objectToPower)
    {
        objectToPower.GetComponent<Shooter>().SwapWeapon(weapon);
    }
}
