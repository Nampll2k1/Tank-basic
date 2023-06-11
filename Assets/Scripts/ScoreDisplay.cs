using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private TankController tank;

    private void Start()
    {
        tank = FindObjectOfType<TankController>();
    }
    void Update()
    {
        if(text != null)
        {
            text.text = "Score: " + tank.score;
        }
    }
}
