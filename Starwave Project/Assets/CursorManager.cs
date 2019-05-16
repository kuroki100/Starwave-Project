using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

    [SerializeField]
    Camera mouseCam;

    CursorLockMode cursorState;

    void Start()
    {
        Cursor.visible = false;
        cursorState = CursorLockMode.Confined;
    }

    void Update () {
        Vector3 cursorPos = mouseCam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
	}
}
