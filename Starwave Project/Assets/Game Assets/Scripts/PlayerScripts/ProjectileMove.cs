using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;
    public float lifeTime;


    private void OnEnable()
    {
        Invoke("hideProj", lifeTime);
    }

    void hideProj()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
