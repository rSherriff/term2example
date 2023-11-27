using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PowerUp : ScriptableObject
{
    abstract public void Apply(GameObject objectToPower);
}
