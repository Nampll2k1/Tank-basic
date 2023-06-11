using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    Timer enemyTimer;
    [SerializeField]
    GameObject enemy;

    void Start()
    {
        enemyTimer = gameObject.AddComponent<Timer>();
        enemyTimer.totalSeconds = 2;
        enemyTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyTimer.Finished)
        {
            GenerateBall();
            enemyTimer.Run();
        }
    }

    void GenerateBall() {
       Instantiate(enemy, Helper.GetRandomPosition(), Quaternion.identity);
    }
}
