using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {

    public float speed = 10;

    public float lifeTime = 3;

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
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * (Time.deltaTime * 2f));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Base" || collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
