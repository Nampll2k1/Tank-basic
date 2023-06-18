using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Serializable]
    public class ObjectData
    {
        public Vector3 position;
        public Quaternion rotation;
    }

    [Serializable]
    public class ObjectDataList
    {
        public ObjectData[] objects;
        public ObjectData tank;
        public int score;
    }

    public ObjectDataList data = new ObjectDataList();
    private string saveFilePath ="data.json";

    [SerializeField]
    GameObject enemy;
    private void Awake()
    {
        LoadGame();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    private void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string jsonData = File.ReadAllText(saveFilePath);
            data = JsonUtility.FromJson<ObjectDataList>(jsonData);


            TankController tank = GameObject.FindFirstObjectByType<TankController>();
            
            tank.score = data.score;
            tank.transform.position = data.tank.position;
            tank.transform.rotation = data.tank.rotation;
            foreach (ObjectData data in data.objects)
            {
                Instantiate(enemy, data.position, data.rotation);
            }
        }

    }

    private void SaveGame()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enermy");
        ObjectData[] objects = new ObjectData[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            objects[i] = new ObjectData();
            objects[i].position = enemies[i].transform.position;
            objects[i].rotation = enemies[i].transform.rotation;
        }


        TankController tank = GameObject.FindFirstObjectByType<TankController>();
        data.tank = new ObjectData();
        
        data.score = tank.score;
        data.tank.position = tank.transform.position;
        data.tank.rotation = tank.transform.rotation;

        data.objects = objects;
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, jsonData);
    }
}
