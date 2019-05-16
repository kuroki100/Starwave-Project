using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    Transform[] enemySpawns;

    [SerializeField]
    float InvokeRate = 1.0f;

    [SerializeField]
    float invokeTime = 1f;

    [SerializeField]
    List <GameObject> enemyPrefab;

    [SerializeField]
    int enemiesPoolSize;

    List<GameObject> enemiesPool;

	void Start ()
    {
        InvokeRepeating("SpawnEnemies", invokeTime, InvokeRate);

        enemiesPool = new List<GameObject>();
        for (int i = 0; i <enemiesPoolSize; i++)
        {
            GameObject enemyObj1 = Instantiate(enemyPrefab[0], enemySpawns[0].position, enemyPrefab[0].transform.rotation);
            GameObject enemyObj2 = Instantiate(enemyPrefab[1], enemySpawns[1].position, enemyPrefab[1].transform.rotation);
            GameObject enemyObj3 = Instantiate(enemyPrefab[2], enemySpawns[2].position, enemyPrefab[2].transform.rotation);
            enemyObj1.SetActive(false);
            enemyObj2.SetActive(false);
            enemyObj3.SetActive(false);
            enemiesPool.Add(enemyObj1);
            enemiesPool.Add(enemyObj2);
            enemiesPool.Add(enemyObj3);

        }
    }
	

	void SpawnEnemies()
    {
        int indexNumber = Random.Range(0, enemySpawns.Length);
        int enemyNum = Random.Range(0, enemyPrefab.Count);

        for (int i = 0; i < enemyPrefab.Count; i++)
        {
            if (!enemiesPool[i].activeInHierarchy)
            {
                Instantiate(enemyPrefab[enemyNum], enemySpawns[indexNumber].position, enemyPrefab[enemyNum].transform.rotation);
                enemyPrefab[i].SetActive(true);
                break;
            }

        }
    }

}
