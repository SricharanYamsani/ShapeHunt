using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class EnemySpawner : MonoBehaviour {

    float spawnTime = 2f;

    public GameObject cubeEnemyPrefab;
    public GameObject sphereEnemyPrefab;
    public GameObject cylinderEnemyPrefab;
    public GameObject DisappearEnemyPrefab;
    public GameObject EnlargeEnemyPrefab;

    public Dictionary<EnemyType, Queue<GameObject>> EDictionary = new Dictionary<EnemyType, Queue<GameObject>>();

    public Queue<GameObject> cubeEnemyPool = new Queue<GameObject>();
    public Queue<GameObject> sphereEnemyPool = new Queue<GameObject>();
    public Queue<GameObject> cylinderEnemyPool = new Queue<GameObject>();
    public Queue<GameObject> disappearEnemyPool = new Queue<GameObject>();
    public Queue<GameObject> EnlargeEnemyPool = new Queue<GameObject>();


    public static EnemySpawner Instance;

    public Transform[] spawnPoints;

    private void Awake()
    {
        Instance = this;

        InitializePools();


        if(GameManager.Instance.GetGameMode() == GameMode.ENDLESS)
            StartCoroutine(EndlessSpawn());
    }

    public void Spawn(EnemyType type)
    {
        GameObject e = (EDictionary[type]).Dequeue();

        //Debug.Log("Instantiated from pool");

        e.SetActive(true);

        e.GetComponent<Enemy>().Init();

        Vector3 spawnPosition = GetSpawnPosition();

        e.transform.position = new Vector3(spawnPosition.x, 0.5f, spawnPosition.z);

    }

    Vector3 GetSpawnPosition()
    {
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].position;
    }


    void InitializePools()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(cubeEnemyPrefab);
            enemy.SetActive(false);
            cubeEnemyPool.Enqueue(enemy);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(sphereEnemyPrefab);
            enemy.SetActive(false);
            sphereEnemyPool.Enqueue(enemy);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(cylinderEnemyPrefab);
            enemy.SetActive(false);
            cylinderEnemyPool.Enqueue(enemy);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(DisappearEnemyPrefab);
            enemy.SetActive(false);
            disappearEnemyPool.Enqueue(enemy);
        }

        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(EnlargeEnemyPrefab);
            enemy.SetActive(false);
            EnlargeEnemyPool.Enqueue(enemy);
        }


        EDictionary.Add(EnemyType.CUBE, cubeEnemyPool);
        EDictionary.Add(EnemyType.SPHERE, sphereEnemyPool);
        EDictionary.Add(EnemyType.CYLINDER, cylinderEnemyPool);
        EDictionary.Add(EnemyType.DISAPPEAR, disappearEnemyPool);
        EDictionary.Add(EnemyType.ENLARGE, EnlargeEnemyPool);
    }

    public void BackToPool(EnemyType type, GameObject enemy)
    {
        enemy.SetActive(false);

        EDictionary[type].Enqueue(enemy);

        //Debug.Log("Back To Pool : " + type.ToString());
    }

    IEnumerator EndlessSpawn()
    {
        while(GameManager.Instance.PlayerOne!=null)
        {
            System.Array values = System.Enum.GetValues(typeof(EnemyType));

            Spawn((EnemyType)values.GetValue(Random.Range(0,values.Length)));

            yield return new WaitForSeconds(spawnTime);
        }
    }
}
