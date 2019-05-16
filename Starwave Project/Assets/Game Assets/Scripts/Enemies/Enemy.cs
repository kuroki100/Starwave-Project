using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public GameObject shotPrefab;
    List<GameObject> shotList;
    public int numberOfShots;

    public float timeBShots;
    private float shotCounter;

    public Transform shotSpawn;
    public float agroRange;
    public Transform target;

    public Image hpBar;

    ScoreCounter findScore;


    private void Start()
    {
        findScore = FindObjectOfType<ScoreCounter>();

        iTween.Init(this.gameObject);
        target = PlayerManager.instance.player.transform;

        shotList = new List<GameObject>();
        for (int i = 0; i < numberOfShots; i++)
        {
            GameObject objProj = Instantiate(shotPrefab, shotSpawn.position, shotSpawn.rotation);
            objProj.SetActive(false);
            shotList.Add(objProj);
        }
    }

    public void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        shotCounter -= Time.deltaTime;

        if (distance <= agroRange && shotCounter <= 0)
        {
            Attack();
        }
    }
    void Attack()
    {
        shotSpawn.LookAt(target.transform);
        transform.LookAt(target.position);

        for (int i = 0; i < shotList.Count; i++)
        {
            if (!shotList[i].activeInHierarchy)
            {
                shotCounter = timeBShots;
                shotList[i].transform.position = shotSpawn.position;
                shotList[i].transform.rotation = transform.rotation;
                shotList[i].SetActive(true);
                break;
            }
            else
            {
                shotCounter = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, agroRange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            findScore.scoreCount += 1;
            hpBar.fillAmount -= 0.20f;
        }
        if (hpBar.fillAmount <= 0 || collision.gameObject.tag == "Base")
        {
            findScore.scoreCount += 20;
            gameObject.SetActive(false);
        }
    }
}
