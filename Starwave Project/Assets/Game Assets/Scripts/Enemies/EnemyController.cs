﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public Transform[] routes;

    private int routeToGo;

    private float tParam;

    private Vector3 enemyPosition;

    public float speedModifier = 0.05f;

    private bool coroutineAllowed;
	
	void Start ()
    {
        routeToGo = 0;
        tParam = 0f;
        coroutineAllowed = true;
	}
	
	
	void Update () {
        if (coroutineAllowed)
        {
            StartCoroutine(GoByTheRoute(routeToGo));
        }

	}

    private IEnumerator GoByTheRoute(int routeNumber)
    {
        coroutineAllowed = false;

        Vector3 p0 = routes[routeNumber].GetChild(0).position;
        Vector3 p1 = routes[routeNumber].GetChild(1).position;
        Vector3 p2 = routes[routeNumber].GetChild(2).position;
        Vector3 p3 = routes[routeNumber].GetChild(3).position;
        
        while(tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            enemyPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;

            transform.position = enemyPosition;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;

        routeToGo += 1;

        coroutineAllowed = true;
        
    }
}
