using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TankController tank = FindObjectOfType<TankController>();
        if (tank != null)
        {
            tank.PlusScore();
        }
        Destroy(gameObject);
    }
}
