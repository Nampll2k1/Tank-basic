using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper {
    public static Vector3 GetRandomPosition()
    {
        Camera mainCamera = Camera.main;

        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float x_axis = Random.Range(-cameraWidth, cameraWidth);
        float y_axis = Random.Range(-cameraHeight, cameraHeight);
        return new Vector3(x_axis, y_axis, 0);
    }

    public static Vector2 getVector2DByDegree(float degree)
    {
        float radian = degree * Mathf.Deg2Rad;
        float sinD = Mathf.Sin(radian);
        float cosD = Mathf.Cos(radian);
        float x = sinD;
        float y = cosD;
        return new Vector2(x, y);
    }
}
   
