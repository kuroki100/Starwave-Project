using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunController : MonoBehaviour {

    [SerializeField]
    GameObject proj;

    [SerializeField]
    Transform PooledProjectiles;

    [SerializeField]
    public float timeBShots;

    private float shotCounter;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Transform firePointTwo;

    [SerializeField]
    int numberOfBullets;

    List<GameObject> projectileList;

    //overheat
    [SerializeField]
    Image overHeatBar;

    [SerializeField]
    float overheat1;

    [SerializeField]
    float overheat2;

    [SerializeField]
    bool canShoot;


    private void Start()
    {
        //overheat
        canShoot = true;
        
        overHeatBar.fillAmount = 0;
       
        projectileList = new List<GameObject>();

        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject objProj = Instantiate(proj, firePoint.position, firePoint.rotation);
            GameObject objProjTwo = Instantiate(proj, firePointTwo.position, firePointTwo.rotation);
            objProj.transform.SetParent(PooledProjectiles);
            objProjTwo.transform.SetParent(PooledProjectiles);
            objProj.SetActive(false);
            objProjTwo.SetActive(false);
            projectileList.Add(objProj);
            projectileList.Add(objProjTwo);
        }
    }


    void Update ()
    {
        shotCounter -= Time.deltaTime;

        if (canShoot == true && (shotCounter <= 0))
        {
            if (Input.GetMouseButton(0) )
            {
                Fire();
                FireTwo();
                overHeatBar.fillAmount += 1.0f / overheat1 * Time.deltaTime;
            }
            if (!Input.GetMouseButton(0))
            {
                overHeatBar.fillAmount -= 0.25f / overheat2 * Time.deltaTime;
            }
        }
        if (overHeatBar.fillAmount == 1)
        {
            canShoot = false;
        }
        if (canShoot == false)
        {
            print("OverHeat!!");

            overHeatBar.fillAmount -= 1.0f / overheat2 * Time.deltaTime;

            if (overHeatBar.fillAmount == 0)
            {
                canShoot = true;
            }
        }
    }

    void Fire()
    {
        for (int i = 0; i < projectileList.Count; i++)
        {
            if (!projectileList[i].activeInHierarchy)
            {
                shotCounter = timeBShots;
                projectileList[i].transform.position = firePoint.position;
                projectileList[i].transform.rotation = firePoint.rotation;
                projectileList[i].SetActive(true);
                break;
            }
            else
            {
                shotCounter = 0;
            }
        }
    }
    void FireTwo()
    {       
        for (int i = 0; i < projectileList.Count; i++)
        {
            if (!projectileList[i].activeInHierarchy)
            {
                shotCounter = timeBShots;
                projectileList[i].transform.position = firePointTwo.position;
                projectileList[i].transform.rotation = firePointTwo.rotation;
                projectileList[i].SetActive(true);
                break;
            }
            else
            {
                shotCounter = 0;
            }
        }

    }
}
