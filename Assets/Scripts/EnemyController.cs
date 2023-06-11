using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float movementSpeed = 5f;
    Vector3 targetPosition;
    [SerializeField]
    GameObject fire;
    [SerializeField]
    AudioClip boom;
    private void Start()
    {
        targetPosition = Helper.GetRandomPosition();
    }
    private void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);

        // Check if the ball has reached the target position
        if (transform.position == targetPosition)
        {
            // Set a new random target position within the viewport of the main camera
           targetPosition = Helper.GetRandomPosition();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("bullet"))
        {
            AudioSource.PlayClipAtPoint(boom, Camera.main.transform.position);
            Destroy(Instantiate(fire, transform.position, transform.rotation),.3f);
            Destroy(gameObject);
        }
    }


}
