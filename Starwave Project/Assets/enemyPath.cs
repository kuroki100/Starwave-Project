using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPath : MonoBehaviour {

    [SerializeField]
    Vector3[] pathPoints;

    void OnDrawGizmos()
    {
        iTween.DrawPath(pathPoints, Color.red);
    }
}
