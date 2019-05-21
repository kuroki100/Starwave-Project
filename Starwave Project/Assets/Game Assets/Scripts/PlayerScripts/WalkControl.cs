using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WalkControl : MonoBehaviour {

    //Walk
    [SerializeField]
    float speed;

    Rigidbody rb;
    Vector3 move;

    //camera rotate
    public Camera cam;

    private Ray rayMouse;
    private Vector3 pos;
    private Vector3 direction;
    private Quaternion rotation;

    [SerializeField]
    Image hpBar;

    public GameObject lose;

    [SerializeField]
    float DamageIntake;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //walk
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));


        //camera rotate
        RaycastHit hit;
        var mousePos = Input.mousePosition;
        rayMouse = cam.ScreenPointToRay(mousePos);
        if (Physics.Raycast(rayMouse.origin, rayMouse.direction, out hit, 10000))
        {
            RotateMouseDirection(gameObject, hit.point);
        }
        else
        {
            var pos = rayMouse.GetPoint(10000);
            RotateMouseDirection(gameObject, pos);
        }
    }

    void FixedUpdate()
    {
        moveChar(move);
    }

    void moveChar(Vector3 direction)
    {
        rb.velocity = direction * speed;
    }
    
    void RotateMouseDirection(GameObject obj, Vector3 destination)
    {
        direction = destination - obj.transform.position;
        direction.y = 0;
        direction = direction.normalized;
        rotation = Quaternion.LookRotation(direction);
        rotation = rotation.normalized;
        obj.transform.localRotation = Quaternion.Slerp(rotation, rotation, 0);
    }

    public Quaternion GetRotation()
    {
        return rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemyProj")
        {
            hpBar.fillAmount -= DamageIntake;
        }
        if (hpBar.fillAmount <= 0)
        {
            Time.timeScale = 0f;
            lose.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}

