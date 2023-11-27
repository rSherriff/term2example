using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Shooter
{
    public float speed;

    void Start()
    {
    }

    void Update()
    {
        float correctedSpeed = speed * Time.deltaTime;
        Vector2 movement = new Vector2(Input.GetAxis("Horizontal") * correctedSpeed, Input.GetAxis("Vertical") * correctedSpeed);
        transform.Translate(movement);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShootDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ShootUp();
        }
    }
}
