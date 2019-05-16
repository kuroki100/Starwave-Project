using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour {

    [SerializeField]
    GameObject[] paths;


    [SerializeField]
    List <GameObject> enemyPrefabs;

    [SerializeField]
    List<Transform> spawnPos;

    [SerializeField]
    float mSpeed, invokeTime, InvokeRate;

    List<GameObject> enemyCloneList;

    // Use this for initialization
    void Start () {
        enemyCloneList = new List<GameObject>();
        enemyCloneList = enemyPrefabs;
	}
	
	// Update is called once per frame
	void Update ()
    {
        InvokeRepeating("PathToTake", invokeTime, InvokeRate);
        
	}

    void PathToTake()
    {
        int pathsToTake = Random.Range(0, spawnPos.Count);
        int randomizeEnemies = Random.Range(0, enemyCloneList.Count);
        Instantiate(enemyCloneList[randomizeEnemies], paths[pathsToTake].transform.position, paths[pathsToTake].transform.rotation);
        iTween.MoveTo(enemyCloneList[randomizeEnemies], iTween.Hash("position", pathsToTake, "speed", mSpeed, "easetype", iTween.EaseType.easeInOutSine));
    }
 
}
