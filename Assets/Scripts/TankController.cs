using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;

    [SerializeField]
    float speerSpeed = 150f;

    public int score { get; set; }
    void Start()
    {
        //score = 0;
    }

    void Update()
    {
        float speer = Time.deltaTime * speerSpeed * Input.GetAxis("Horizontal");
        float move = Time.deltaTime * moveSpeed * Input.GetAxis("Vertical");
        transform.Translate(0, move, 0);
        transform.Rotate(0, 0, -speer);
    }

    public void PlusScore()
    {
        score += 10;
    }
}
