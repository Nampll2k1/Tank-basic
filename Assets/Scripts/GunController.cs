using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    public float Impulse = 20f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameObject bulletObject =  Instantiate(bullet, transform.position, transform.rotation);
            Rigidbody2D bullet_body = bulletObject.GetComponent<Rigidbody2D>();
            bullet_body.AddForce(Helper.getVector2DByDegree(-transform.eulerAngles.z) * 20, ForceMode2D.Impulse);
        }

    }

 
}
