using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Shooter
{
    public float shootFrequency;
    void Start()
    {
        ShootDown();
    }
}
