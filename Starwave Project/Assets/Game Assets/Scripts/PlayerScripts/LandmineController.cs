using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandmineController : MonoBehaviour
{
    public GameObject skillQ;
    public int landMineCount = 5;
    public float qCooldown = 5;
    private float nextQ = 0;
    public float areaRadius = 20;

    //public float lmDuration = 3;

    Vector3 worldPos;

    void Update ()
    {
        //float distance = Vector3.Distance(Input.mousePosition, transform.position);

        SkillQ();
    }

    void SkillQLayout()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000))
        {
            worldPos = hit.point;
        }
        Instantiate(skillQ, worldPos, Quaternion.identity);
    }

    void SkillQ()
    {
        

        if (Time.time > nextQ)
        {
            if (landMineCount > 0 && Input.GetKeyDown(KeyCode.Q))
            {
                landMineCount -= 1;
                SkillQLayout();
                print(" you have " + landMineCount + " mines of 5.");

            }
            else if (landMineCount == 0)
            {
                nextQ = Time.time + qCooldown;
                print(" Cooldown has started.");

                landMineCount = 5;
                print("you have regenerated your Land Mine you have now: " + landMineCount + ".");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, areaRadius);
    }
}

